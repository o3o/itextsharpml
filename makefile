NAME = itextsharpml.dll
VERSION = 4.3.0
TARGET = library

SRC = $(shell find iTextSharp/ -name "*.cs")
SRC += $(shell find System/ -name "*.cs")
SRC += $(shell find srcbc/ -name "*.cs")
SRC += AssemblyInfo.cs Contracts.cs

REFS = System.Data.dll System.Drawing.dll
REFS_FLAG = $(addprefix -r:, $(REFS))
#PKG_FLAG +=-pkg:gtk-sharp-2.0
RES_OPT = -res:iTextSharp/text/pdf/fonts/Courier.afm \
	-res:iTextSharp/text/pdf/fonts/Courier-Bold.afm \
	-res:iTextSharp/text/pdf/fonts/Courier-BoldOblique.afm \
	-res:iTextSharp/text/pdf/fonts/Courier-Oblique.afm \
	-res:iTextSharp/text/pdf/fonts/glyphlist.txt \
	-res:iTextSharp/text/pdf/fonts/Helvetica.afm \
	-res:iTextSharp/text/pdf/fonts/Helvetica-Bold.afm \
	-res:iTextSharp/text/pdf/fonts/Helvetica-BoldOblique.afm \
	-res:iTextSharp/text/pdf/fonts/Helvetica-Oblique.afm \
	-res:iTextSharp/text/pdf/fonts/Symbol.afm \
	-res:iTextSharp/text/pdf/fonts/Times-Bold.afm \
	-res:iTextSharp/text/pdf/fonts/Times-BoldItalic.afm \
	-res:iTextSharp/text/pdf/fonts/Times-Italic.afm \
	-res:iTextSharp/text/pdf/fonts/Times-Roman.afm \
	-res:iTextSharp/text/pdf/fonts/ZapfDingbats.afm 


ZIP = $(BIN)/$(NAME)
ZIP += $(BIN)/log4net.dll
#ZIP += $(wildcard glade/*.glade)
#ZIP += $(wildcard config/*.sdl)
#ZIP += $(wildcard config/*.yaml)
#ZIP += $(wildcard support/*.sdl)

ZIP_SRC = $(ZIP) $(SRC) README.md CHANGELOG.md makefile $(SRC_TEST)

########
# Test #
########
TEST_SOURCE_DIR = tests
SRC_TEST = $(filter-out $(ROOT_SOURCE_DIR)/App.cs, $(SRC))
SRC_TEST += $(wildcard $(TEST_SOURCE_DIR)/*.cs)

REFS_TEST = $(REFS)
REFS_TEST += nunitlite.dll
REFS_TEST += nunit.framework.dll
REFS_TEST += NSubstitute.dll
REFS_FLAG_TEST = $(addprefix -r:, $(REFS_TEST))
	PKG_FLAG_TEST = $(PKG_FLAG)

###############
# Common part #
###############
BIN = bin
CSC = mcs

BASE_NAME = $(basename $(NAME))
#CSCFLAGS += -debug
#ISO-1, ISO-2, 3, 4, 5, Default or Experimental
#CSCFLAGS += -langversion:3
#anycpu|anycpu32bitpreferred|arm|x86|x64|itanium
#CSCFLAGS += -platform:x86

# vedere /usr/lib/mono
#CSCFLAGS += -sdk:2|4|4.5
CSCFLAGS += -nologo
CSCFLAGS += -target:$(TARGET)
CSCFLAGS += -lib:$(BIN)
	CSCFLAGS += $(RES_OPT)

NAME_TEST = test-runner
CSCFLAGS_TEST += -debug -nologo -target:exe
CSCFLAGS_TEST += -lib:$(BIN)

NUNIT_OPT =--noheader --noresult

PUBLISH_DIR = $(CS_DIR)/lib/Microline/$(BASE_NAME)/$(VERSION)
ZIP_PREFIX = $(BASE_NAME)-$(VERSION)

.PHONY: all clean clobber test testv ver var pkgall pkg pkgtar pkgsrc publish

DEFAULT: all
all: builddir $(BIN)/$(NAME)

WHERE += $(if $(W), --where "$(W)")

## make test W=test_name T=option
test: builddir $(BIN)/$(NAME_TEST)
	$(BIN)/$(NAME_TEST) $(NUNIT_OPT) $(T) $(WHERE)

testv: builddir $(BIN)/$(NAME_TEST)
	$(BIN)/$(NAME_TEST) $(NUNIT_OPT) -v $(T) $(WHERE)

builddir:
	@mkdir -p $(BIN)

$(BIN)/$(NAME): $(SRC) | builddir
	$(CSC) $(CSCFLAGS) $(REFS_FLAG) $(PKG_FLAG) -out:$@ $^

$(BIN)/$(NAME_TEST): $(SRC_TEST) | builddir
	$(CSC) $(CSCFLAGS_TEST) $(REFS_FLAG_TEST) $(PKG_FLAG_TEST) -out:$@ $^

pkgdir:
	@mkdir -p pkg

pkgall: pkg pkgtar pkgsrc

pkg: pkgdir | pkg/$(ZIP_PREFIX).zip

pkg/$(ZIP_PREFIX).zip: $(ZIP)
	zip $@ $(ZIP)

pkgtar: pkgdir | pkg/$(ZIP_PREFIX).tar.bz2

pkg/$(ZIP_PREFIX).tar.bz2: $(ZIP)
	tar -jcf $@ $^

pkgsrc: pkgdir | pkg/$(ZIP_PREFIX)-src.tar.bz2

pkg/$(ZIP_PREFIX)-src.tar.bz2: $(ZIP_SRC)
	tar -jcf $@ $^

changelog: CHANGELOG.txt

CHANGELOG.txt: CHANGELOG.md
	pandoc -f markdown_github -t plain $^ > $@


publishdir:
	@mkdir -p $(PUBLISH_DIR)

publish: publishdir
	cp -u --verbose --backup=t --preserve=all $(BIN)/$(NAME) $(PUBLISH_DIR)

tags: $(SRC)
	ctags $^

ver:
	@echo $(VERSION)

clean:
	-rm -f $(BIN)/$(NAME)
	-rm -f $(BIN)/$(NAME_TEST)
	-rm -f $(BIN)/*.mdb

clobber: clean
	-rm -Rf $(BIN)/*.dll

var:
	@echo NAME:$(NAME)
	@echo SRC:$(SRC)
	@echo 
	@echo REFS: $(REFS)
	@echo REFS_FLAG: $(REFS_FLAG)
	@echo PKG_FLAG: $(PKG_FLAG)
	@echo 
	@echo CSCFLAGS: $(CSCFLAGS)
	@echo 
	@echo SRC_TEST:$(SRC_TEST)
	@echo 
	@echo REFS_TEST: $(REFS_TEST)
	@echo REFS_FLAG_TEST: $(REFS_FLAG_TEST)
	@echo PKG_FLAG_TEST: $(PKG_FLAG_TEST)
	@echo 
	@echo CSCFLAGS_TEST: $(CSCFLAGS_TEST)
	@echo 
	@echo ZIP: $(ZIP)
	@echo 
	@echo VERSION: $(VERSION)

#include i18n.makefile
