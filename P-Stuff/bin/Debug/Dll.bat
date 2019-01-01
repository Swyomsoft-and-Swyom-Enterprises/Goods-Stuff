ngen install CSPEncryptWr.dll
ngen install CSPContnr.dll
ngen install DmpCSP.dll
ngen install DcpCSP.dll
ngen install DrmGmPtCSP.dll
ngen install DgCntPtCSP.dll
ngen install DcFlgCSP.dll
ngen install DCalcQty.dll
ngen install DcaNrs.dll
ngen install DgmPtCAlt.dll
ngen install DGmPtCA.dll
ngen install CSPDbtracK.dll
ngen install DBxContnr.dll
ngen install CSP.dll
ngen install SmallBasicLibrary.dll
ngen install ToneGen.dll
ngen install GenMthCalc.dll
ngen install CompactADb.dll
ngen install CSPs.dll
ngen install OptMthd.dll
ngen install CSPImgPrnt.dll
ngen install CSPStrtCont.dll
ngen install SysInfo.dll


gacutil -i CSPEncryptWr.dll
gacutil -i CSPContnr.dll
gacutil -i DmpCSP.dll
gacutil -i DcpCSP.dll
gacutil -i DrmGmPtCSP.dll
gacutil -i DgCntPtCSP.dll
gacutil -i DcFlgCSP.dll
gacutil -i DCalcQty.dll
gacutil -i DcaNrs.dll
gacutil -i DgmPtCAlt.dll
gacutil -i DGmPtCA.dll
gacutil -i CSPDbtracK.dll
gacutil -i DBxContnr.dll
gacutil -i CSP.dll
gacutil -i SmallBasicLibrary.dll
gacutil -i ToneGen.dll
gacutil -i GenMthCalc.dll
gacutil -i CompactADb.dll
gacutil -i CSPs.dll
gacutil -i OptMthd.dll
gacutil -i CSPImgPrnt.dll
gacutil -i CSPStrtCont.dll
gacutil -i SysInfo.dll


RegSvr32 "SkySwReg.dll"

regasm CSPEncryptWr.dll
regasm CSPContnr.dll
regasm DmpCSP.dll
regasm DcpCSP.dll
regasm DrmGmPtCSP.dll
regasm DgCntPtCSP.dll
regasm DcFlgCSP.dll
regasm DCalcQty.dll
regasm DcaNrs.dll
regasm DgmPtCAlt.dll
regasm DGmPtCA.dll
regasm CSPDbtracK.dll
regasm DBxContnr.dll
regasm CSP.dll
regasm SmallBasicLibrary.dll
regasm ToneGen.dll
regasm GenMthCalc.dll
regasm CompactADb.dll
regasm CSPs.dll
regasm OptMthd.dll
regasm CSPImgPrnt.dll
regasm CSPStrtCont.dll
regasm SysInfo.dll

