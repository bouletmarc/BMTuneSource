using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

internal class Class32_Locations
{
    private Class18 class18_0;
    //List<long> OldLocations = new List<long>();
    //List<long> NewLocations = new List<long>();

    public void LoadReference(ref Class18 thisC18)
    {
        class18_0 = thisC18;
    }

    public void ResetAddresseForVersion(int Version)
    {
        if (Version != this.class18_0.LastLocationLoaded)
        {
            this.class18_0.LastLocationLoaded = Version;

            //Load Original Locations
            this.class18_0.method_145();

            //Load all new locations representative to 1.11 and beyond
            if (Version >= 114 && Version < 116) Reset114();
            if (Version >= 116) Reset116();

            //Reset Some Parameters Locations
            this.class18_0.GetInputsOutputsLocations();
            this.class18_0.GetECT_IAT_Temp_Area();
            this.class18_0.Get_TestOutputs_Area();
        }

    }

    private void Reset114()
    {
        this.class18_0.class13_u_0.long_43 = 0x5fd2L;
        this.class18_0.class13_u_0.long_44 = 0x5fceL;
        this.class18_0.class13_u_0.long_46 = 0x606bL;
        this.class18_0.class13_u_0.long_54 = 0x5fd1L;
        this.class18_0.class13_u_0.long_55 = 0x5fcdL;
        this.class18_0.class13_u_0.long_58 = 0x606cL;      //Fcut delay (overrun fcut)
        this.class18_0.class13_u_0.long_59 = 0x5fcaL;
        this.class18_0.class13_u_0.long_61 = 0x5fc5L;      //Fcut Leak
        this.class18_0.class13_u_0.long_60 = 0x5fc6L;      //FCut Leak
        this.class18_0.class13_u_0.long_62 = 0x5fc7L;      //FCut Leak
        this.class18_0.class13_u_0.long_79 = 0x606aL;
        this.class18_0.class13_u_0.long_82 = 0x6014L;      //gear based rev limiter
        this.class18_0.class13_u_0.long_83 = 0x6013L;      //rev limiter ect threshold (cold/hot)
        this.class18_0.class13_u_0.long_84 = 0x6012L;
        this.class18_0.class13_u_0.long_85 = 0x6020L;
        this.class18_0.class13_u_0.long_88 = 0x5fd3L;      //kill injector
        this.class18_0.class13_u_0.long_89 = 0x5f87L;      //Calibration Area (previous: 0x5f28L; ectune: 0x5f44L)
        this.class18_0.class13_u_0.long_116 = 0x5fd4L;     //ign sync on/off
        this.class18_0.class13_u_0.long_132 = 0x6069L;     //ect protect, above ect
        this.class18_0.class13_u_0.long_133 = 0x6068L;     //ect protect enabled
        this.class18_0.class13_u_0.long_135 = 0x5ffbL;     //ect protect limit to rpm
        this.class18_0.class13_u_0.long_136 = 0x6029L;
        this.class18_0.class13_u_0.long_150 = 0x6004L;     //fts rpm
        this.class18_0.class13_u_0.long_151 = 0x6002L;     //fts above tps
        this.class18_0.class13_u_0.long_152 = 0x6003L;     //fts gear based rpm enable
        this.class18_0.class13_u_0.long_153 = 0x5fddL;     //fts type (fixed or adjustable rpm)
        this.class18_0.class13_u_0.long_154 = 0x5fdcL;     //fts antilag enabled
        this.class18_0.class13_u_0.long_155 = 0x5fdaL;     //fts fuel
        this.class18_0.class13_u_0.long_156 = 0x5fd9L;     //fts ign retard
        this.class18_0.class13_u_0.long_162 = 0x6011L;     //FTL Antilag ign mode (static, by retard)
        this.class18_0.class13_u_0.long_163 = 0x6010L;     //FTL retard static
        this.class18_0.class13_u_0.long_171 = 0x5fd8L;     //Burnout Control Rpm
        this.class18_0.class13_u_0.long_172 = 0x5fd7L;     //Burnout Control Input
        this.class18_0.class13_u_0.long_173 = 0x5fd5L;     //Burnout Control
        this.class18_0.class13_u_0.long_189 = 0x5fc8L;     //Gear Corr Above Load
        this.class18_0.class13_u_0.long_192 = 0x6021L;     //Idle Ign Corr Enabled
        this.class18_0.class13_u_0.long_193 = 0x6022L;     //Idle Ign Corr Above ect
        this.class18_0.class13_u_0.long_195 = 0x6027L;
        this.class18_0.class13_u_0.long_196 = 0x6025L;
        this.class18_0.class13_u_0.long_197 = 0x6026L;
        this.class18_0.class13_u_0.long_198 = 0x6023L; 
        this.class18_0.class13_u_0.long_199 = 0x6024L;
        this.class18_0.class13_u_0.long_200 = 0x6028L;
        this.class18_0.class13_u_0.long_217 = 0x5fdeL;
        this.class18_0.class13_u_0.long_231 = 0x5fffL;
        this.class18_0.class13_u_0.long_232 = 0x6000L;
        this.class18_0.class13_u_0.long_233 = 0x6001L;
        this.class18_0.class13_u_0.long_237 = 0x6037L;
        this.class18_0.class13_u_0.long_239 = 0x5ff7L;
        this.class18_0.class13_u_0.long_240 = 0x5ff8L;
        this.class18_0.class13_u_0.long_242 = 0x5fcfL;
        this.class18_0.class13_u_0.long_256 = 0x606dL;
        this.class18_0.class13_u_0.long_260 = 0x60a5L;
        this.class18_0.class13_u_0.long_261 = 0x608fL;
        this.class18_0.class13_u_0.long_262 = 0x6079L;
        this.class18_0.class13_u_0.long_263 = 0x60bbL;
        this.class18_0.class13_u_0.long_264 = 0x6037L;
        this.class18_0.class13_u_0.long_265 = 0x5fefL;
        this.class18_0.class13_u_0.long_266 = 0x602bL;
        this.class18_0.class13_u_0.long_268 = 0x5ff9L;
        this.class18_0.class13_u_0.long_269 = 0x6033L;
        this.class18_0.class13_u_0.long_270 = 0x5fe7L;
        this.class18_0.class13_u_0.long_310 = 0x60c5L;
        this.class18_0.class13_u_0.long_311 = 0x60dbL;
        this.class18_0.class13_u_0.long_313 = 0x603bL;
        this.class18_0.class13_u_0.long_314 = 0x603eL;
        this.class18_0.class13_u_0.long_315 = 0x603fL;
        this.class18_0.class13_u_0.long_316 = 0x603cL;
        this.class18_0.class13_u_0.long_317 = 0x603dL;
        this.class18_0.class13_u_0.long_318 = 0x6041L;
        this.class18_0.class13_u_0.long_319 = 0x6040L;
        this.class18_0.class13_u_0.long_320 = 0x6042L;
        this.class18_0.class13_u_0.long_321 = 0x6043L;
        this.class18_0.class13_u_0.long_322 = 0x6045L;
        this.class18_0.class13_u_0.long_323 = 0x6047L;
        this.class18_0.class13_u_0.long_324 = 0x6048L;
        this.class18_0.class13_u_0.long_325 = 0x6049L;
        this.class18_0.class13_u_0.long_326 = 0x604aL;
        this.class18_0.class13_u_0.long_327 = 0x604bL;
        this.class18_0.class13_u_0.long_328 = 0x604cL;
        this.class18_0.class13_u_0.long_329 = 0x604dL;
        this.class18_0.class13_u_0.long_330 = 0x604fL;
        this.class18_0.class13_u_0.long_331 = 0x604eL;
        this.class18_0.class13_u_0.long_332 = 0x60fcL;
        this.class18_0.class13_u_0.long_333 = 0x6112L;
        this.class18_0.class13_u_0.long_335 = 0x6050L;
        this.class18_0.class13_u_0.long_336 = 0x6053L;
        this.class18_0.class13_u_0.long_337 = 0x6054L;
        this.class18_0.class13_u_0.long_338 = 0x6051L;
        this.class18_0.class13_u_0.long_339 = 0x6052L;
        this.class18_0.class13_u_0.long_340 = 0x6056L;
        this.class18_0.class13_u_0.long_341 = 0x6055L;
        this.class18_0.class13_u_0.long_342 = 0x6057L;
        this.class18_0.class13_u_0.long_343 = 0x6058L;
        this.class18_0.class13_u_0.long_344 = 0x605aL;
        this.class18_0.class13_u_0.long_345 = 0x605cL;
        this.class18_0.class13_u_0.long_346 = 0x605dL;
        this.class18_0.class13_u_0.long_347 = 0x605eL;
        this.class18_0.class13_u_0.long_348 = 0x605fL;
        this.class18_0.class13_u_0.long_349 = 0x6060L;
        this.class18_0.class13_u_0.long_350 = 0x6061L;
        this.class18_0.class13_u_0.long_351 = 0x6062L;
        this.class18_0.class13_u_0.long_352 = 0x6064L;
        this.class18_0.class13_u_0.long_353 = 0x6063L;
        this.class18_0.class13_u_0.long_370 = 0x6030L;
        this.class18_0.class13_u_0.long_371 = 0x6031L;
        this.class18_0.class13_u_0.long_372 = 0x6032L;
        this.class18_0.class13_u_0.long_373 = 0x602cL;
        this.class18_0.class13_u_0.long_377 = 0x5fdfL; //lean protect min rpm
        this.class18_0.class13_u_0.long_378 = 0x5fe1L; //lean protect min tps
        this.class18_0.class13_u_0.long_379 = 0x5fe3L; //lean protect
        this.class18_0.class13_u_0.long_380 = 0x5fe2L; //lean protect
        this.class18_0.class13_u_0.long_381 = 0x5fe4L; //lean protect
        this.class18_0.class13_u_0.long_382 = 0x5fe5L; //lean protect
        this.class18_0.class13_u_0.long_383 = 0x6034L; //lean protect
        this.class18_0.class13_u_0.long_384 = 0x5fe6L; //lean protect
        this.class18_0.class13_u_0.long_385 = 0x6035L; //lean protect
        this.class18_0.class13_u_0.long_386 = 0x6036L; //lean protect
        this.class18_0.class13_u_0.long_402 = 0x5fb3L;     //FTS Speed
        this.class18_0.class13_u_0.long_460 = 0x5f9cL;     //FlexFuel Ethanol Content
        this.class18_0.class13_u_0.long_461 = 0x5f8aL;     //FlexFuel Fuel - Closeloop
        //this.class18_0.class13_u_0.long_463 = 0x5f99L;     //FlexFuel Fuel - Cranking
        this.class18_0.class13_u_0.long_464 = 0x5fa4L;     //FlexFuel Ignition - Closeloop
        /*this.class18_0.class13_u_0.long_460 = 0x5f9cL;     //FlexFuel Ethanol Content
        this.class18_0.class13_u_0.long_461 = 0x5f78L;     //FlexFuel Fuel - Closeloop
        this.class18_0.class13_u_0.long_463 = 0x5f8aL;     //FlexFuel Fuel - Cranking
        this.class18_0.class13_u_0.long_464 = 0x5fa4L;     //FlexFuel Ignition - Closeloop*/
        //this.class18_0.class13_u_0.long_494 = 0x5f77L;     //Ign Cut Mod (With fuel/ign mod or not)
        this.class18_0.class13_u_0.long_494 = 0x5f89L;     //Ign Cut Mod (With fuel/ign mod or not)

        this.class18_0.class13_u_0.long_89 = 0x5f80L;      //Calibration Area (previous: 0x5f28L; ectune: 0x5f44L)
        this.class18_0.class13_u_0.long_493 = 0x5f88L;     //Ign Cut Mod (With time millisecond mod or not)
    }

    private void Reset116()
    {
        this.class18_0.class13_u_0.long_0 = 0x621aL;       //manual edit 1.11
        this.class18_0.class13_u_0.long_1 = 0x621cL;       //manual edit 1.11
        this.class18_0.class13_u_0.long_2 = 0x6219L;       //manual edit 1.11
        this.class18_0.class13_u_0.long_24 = 0x62c3L;
        this.class18_0.class13_u_0.long_25 = 0x62c5L;      //this lcoation +1 refer to injectors index
        this.class18_0.class13_u_0.long_31 = 0x622cL;
        this.class18_0.class13_u_0.long_32 = 0x622dL;
        this.class18_0.class13_u_0.long_33 = 0x621eL;
        this.class18_0.class13_u_0.long_34 = 0x622aL;
        this.class18_0.class13_u_0.long_35 = 0x6220L;
        this.class18_0.class13_u_0.long_36 = 0x6222L;
        this.class18_0.class13_u_0.long_37 = 0x6224L;
        this.class18_0.class13_u_0.long_38 = 0x6226L;
        this.class18_0.class13_u_0.long_39 = 0x6228L;      //injector overall fuel trim
        this.class18_0.class13_u_0.long_41 = 0x63abL;
        this.class18_0.class13_u_0.long_43 = 0x60efL;
        this.class18_0.class13_u_0.long_44 = 0x60ebL;
        this.class18_0.class13_u_0.long_45 = 0x6319L;
        this.class18_0.class13_u_0.long_46 = 0x6188L;
        this.class18_0.class13_u_0.long_47 = 0x6310L;
        this.class18_0.class13_u_0.long_48 = 0x632bL;
        this.class18_0.class13_u_0.long_49 = 0x6311L;
        this.class18_0.class13_u_0.long_50 = 0x6312L;
        this.class18_0.class13_u_0.long_51 = 0x6316L;
        this.class18_0.class13_u_0.long_52 = 0x6656L;
        this.class18_0.class13_u_0.long_53 = 0x6313L;
        this.class18_0.class13_u_0.long_54 = 0x60eeL;
        this.class18_0.class13_u_0.long_55 = 0x60eaL;
        this.class18_0.class13_u_0.long_56 = 0x6314L;
        this.class18_0.class13_u_0.long_58 = 0x6189L;      //Fcut delay (overrun fcut)
        this.class18_0.class13_u_0.long_59 = 0x60e7L;
        this.class18_0.class13_u_0.long_61 = 0x60e2L;      //Fcut Leak
        this.class18_0.class13_u_0.long_60 = 0x60e3L;      //FCut Leak
        this.class18_0.class13_u_0.long_62 = 0x60e4L;      //FCut Leak
        this.class18_0.class13_u_0.long_63 = 0x66a8L;
        this.class18_0.class13_u_0.long_64 = 0x6330L;
        this.class18_0.class13_u_0.long_66 = 0x6328L;
        this.class18_0.class13_u_0.long_65 = 0x6315L;
        this.class18_0.class13_u_0.long_67 = 0x6327L;
        this.class18_0.class13_u_0.long_71 = 0x6242L;
        this.class18_0.class13_u_0.long_72 = 0x6243L;
        this.class18_0.class13_u_0.long_75 = 0x6318L;
        this.class18_0.class13_u_0.long_76 = 0x628cL;
        this.class18_0.class13_u_0.long_77 = 0x62b7L;
        this.class18_0.class13_u_0.long_78 = 0x62c4L;
        this.class18_0.class13_u_0.long_79 = 0x6187L;
        this.class18_0.class13_u_0.long_80 = 0x62ebL;
        this.class18_0.class13_u_0.long_81 = 0x632dL;
        this.class18_0.class13_u_0.long_82 = 0x6131L;      //gear based rev limiter
        this.class18_0.class13_u_0.long_83 = 0x6130L;      //rev limiter ect threshold (cold/hot)
        this.class18_0.class13_u_0.long_84 = 0x612fL;
        this.class18_0.class13_u_0.long_85 = 0x613dL;
        this.class18_0.class13_u_0.long_88 = 0x60f0L;      //kill injector
        //this.class18_0.class13_u_0.long_89 = 0x60a4L;      //Calibration Area (previous: 0x5f28L; ectune: 0x5f44L)
        //this.class18_0.class13_u_0.long_89 = 0x6020L;      //Calibration Area (previous: 0x5f28L; ectune: 0x5f44L)
        this.class18_0.class13_u_0.long_95 = 0x62f5L;
        this.class18_0.class13_u_0.long_100 = 0x631aL;
        this.class18_0.class13_u_0.long_101 = 0x631fL;     //ignition sync value
        this.class18_0.class13_u_0.long_102 = 0x6325L;
        this.class18_0.class13_u_0.long_103 = 0x6288L;
        this.class18_0.class13_u_0.long_104 = 0x6289L;
        this.class18_0.class13_u_0.long_105 = 0x628aL;
        this.class18_0.class13_u_0.long_106 = 0x628bL;     //Fan control enabled
        this.class18_0.class13_u_0.long_110 = 0x628cL;
        this.class18_0.class13_u_0.long_111 = 0x62dcL;
        this.class18_0.class13_u_0.long_112 = 0x631dL;
        this.class18_0.class13_u_0.long_113 = 0x6320L;
        this.class18_0.class13_u_0.long_114 = 0x6255L;
        this.class18_0.class13_u_0.long_115 = 0x6256L;
        this.class18_0.class13_u_0.long_116 = 0x60f1L;     //ign sync on/off
        this.class18_0.class13_u_0.long_117 = 0x625fL;     //mil shiftlight enable
        this.class18_0.class13_u_0.long_118 = 0x6260L;     //mil shiftlight per Gear enable
        this.class18_0.class13_u_0.long_119 = 0x6261L;
        this.class18_0.class13_u_0.long_120 = 0x6263L;
        this.class18_0.class13_u_0.long_121 = 0x625bL;
        this.class18_0.class13_u_0.long_122 = 0x625dL;
        this.class18_0.class13_u_0.long_123 = 0x6257L;
        this.class18_0.class13_u_0.long_124 = 0x6258L;
        this.class18_0.class13_u_0.long_125 = 0x625aL;
        this.class18_0.class13_u_0.long_126 = 0x626dL;     //Boost cut enabled
        this.class18_0.class13_u_0.long_127 = 0x626eL;     //Boost cut Cold Load value
        this.class18_0.class13_u_0.long_128 = 0x627bL;     //Boost cut Hot Load value
        this.class18_0.class13_u_0.long_129 = 0x627cL;     //Boost cut ect threshold
        this.class18_0.class13_u_0.long_130 = 0x627aL;     //Boost cut activate boost cut if DTC
        this.class18_0.class13_u_0.long_131 = 0x62b8L;     //Boost cut limit rpm type (1200rpm or set at current rpm)
        this.class18_0.class13_u_0.long_132 = 0x6186L;     //ect protect, above ect
        this.class18_0.class13_u_0.long_133 = 0x6185L;     //ect protect enabled
        this.class18_0.class13_u_0.long_135 = 0x6118L;     //ect protect limit to rpm
        this.class18_0.class13_u_0.long_136 = 0x6146L;
        this.class18_0.class13_u_0.long_137 = 0x626fL;
        this.class18_0.class13_u_0.long_138 = 0x6270L;
        this.class18_0.class13_u_0.long_139 = 0x6272L;
        this.class18_0.class13_u_0.long_140 = 0x6273L;     //launch-FTL minimum RPM
        this.class18_0.class13_u_0.long_141 = 0x6275L;
        this.class18_0.class13_u_0.long_142 = 0x62ecL;
        this.class18_0.class13_u_0.long_143 = 0x6282L;
        this.class18_0.class13_u_0.long_144 = 0x6271L;
        this.class18_0.class13_u_0.long_147 = 0x6276L;
        this.class18_0.class13_u_0.long_148 = 0x6277L;
        this.class18_0.class13_u_0.long_149 = 0x6278L;
        this.class18_0.class13_u_0.long_150 = 0x6121L;     //fts rpm
        this.class18_0.class13_u_0.long_151 = 0x611fL;     //fts above tps
        this.class18_0.class13_u_0.long_152 = 0x6120L;     //fts gear based rpm enable
        this.class18_0.class13_u_0.long_153 = 0x60faL;     //fts type (fixed or adjustable rpm)
        this.class18_0.class13_u_0.long_154 = 0x60f9L;     //fts antilag enabled
        this.class18_0.class13_u_0.long_155 = 0x60f7L;     //fts fuel
        this.class18_0.class13_u_0.long_156 = 0x60f6L;     //fts ign retard
        this.class18_0.class13_u_0.long_157 = 0x6281L;     //fts enabled
        this.class18_0.class13_u_0.long_158 = 0x627dL;     //FTL antilag above tps
        this.class18_0.class13_u_0.long_159 = 0x627eL;     //FTL fuel
        this.class18_0.class13_u_0.long_160 = 0x6280L;     //FTL Retard
        this.class18_0.class13_u_0.long_162 = 0x612eL;     //FTL Antilag ign mode (static, by retard)
        this.class18_0.class13_u_0.long_163 = 0x612dL;     //FTL retard static
        this.class18_0.class13_u_0.long_171 = 0x60f5L;     //Burnout Control Rpm
        this.class18_0.class13_u_0.long_172 = 0x60f4L;     //Burnout Control Input
        this.class18_0.class13_u_0.long_173 = 0x60f2L;     //Burnout Control
        this.class18_0.class13_u_0.long_174 = 0x63bfL;     //IAT Corr Table #1
        this.class18_0.class13_u_0.long_176 = 0x634bL;     //IAT Corr Table #2
        this.class18_0.class13_u_0.long_178 = 0x6428L;     //ECT Corr Table #1
        this.class18_0.class13_u_0.long_179 = 0x65f9L;     //Crank Corr Table
        this.class18_0.class13_u_0.long_180 = 0x6238L;     //Enabled Ign Corr
        this.class18_0.class13_u_0.long_181 = 0x6239L;     //disable ign corr above Load
        this.class18_0.class13_u_0.long_183 = 0x6513L;     //Individual Cyl Corr Table #1
        this.class18_0.class13_u_0.long_184 = 0x6251L;     //Individual Cyl Corr Table #2
        this.class18_0.class13_u_0.long_185 = 0x652fL;     //Injector Table
        this.class18_0.class13_u_0.long_186 = 0x6245L;     //Gear Corr Table #1
        this.class18_0.class13_u_0.long_188 = 0x6244L;     //Gear Corr Above VSS
        this.class18_0.class13_u_0.long_187 = 0x624bL;     //Gear Corr Table #2
        this.class18_0.class13_u_0.long_189 = 0x60e5L;     //Gear Corr Above Load
        this.class18_0.class13_u_0.long_190 = 0x649fL;     //Closeloop Table
        this.class18_0.class13_u_0.long_192 = 0x613eL;     //Idle Ign Corr Enabled
        this.class18_0.class13_u_0.long_193 = 0x613fL;     //Idle Ign Corr Above ect
        this.class18_0.class13_u_0.long_195 = 0x6144L;
        this.class18_0.class13_u_0.long_196 = 0x6142L;
        this.class18_0.class13_u_0.long_197 = 0x6143L;
        this.class18_0.class13_u_0.long_198 = 0x6140L;
        this.class18_0.class13_u_0.long_199 = 0x6141L;
        this.class18_0.class13_u_0.long_200 = 0x6145L;
        this.class18_0.class13_u_0.long_206 = 0x622eL;
        this.class18_0.class13_u_0.long_207 = 0x622fL;
        this.class18_0.class13_u_0.long_208 = 0x6230L;
        this.class18_0.class13_u_0.long_209 = 0x64b7L;
        this.class18_0.class13_u_0.long_210 = 0x64abL;
        this.class18_0.class13_u_0.long_211 = 0x6284L;
        this.class18_0.class13_u_0.long_212 = 0x6286L;
        this.class18_0.class13_u_0.long_213 = 0x62f2L;
        this.class18_0.class13_u_0.long_215 = 0x62f4L;
        this.class18_0.class13_u_0.long_216 = 0x62f1L;
        this.class18_0.class13_u_0.long_217 = 0x60fbL;
        this.class18_0.class13_u_0.long_218 = 0x630fL;
        this.class18_0.class13_u_0.long_219 = 0x6326L;
        this.class18_0.class13_u_0.long_220 = 0x623cL;
        this.class18_0.class13_u_0.long_221 = 0x66b0L;
        this.class18_0.class13_u_0.long_223 = 0x623bL;
        this.class18_0.class13_u_0.long_224 = 0x6240L;
        this.class18_0.class13_u_0.long_225 = 0x6241L;
        this.class18_0.class13_u_0.long_227 = 0x623eL;
        this.class18_0.class13_u_0.long_228 = 0x623dL;
        this.class18_0.class13_u_0.long_229 = 0x623fL;
        this.class18_0.class13_u_0.long_230 = 0x623aL;
        this.class18_0.class13_u_0.long_231 = 0x611cL;
        this.class18_0.class13_u_0.long_232 = 0x611dL;
        this.class18_0.class13_u_0.long_233 = 0x611eL;
        this.class18_0.class13_u_0.long_234 = 0x6332L;
        this.class18_0.class13_u_0.long_235 = 0x6236L;
        this.class18_0.class13_u_0.long_236 = 0x631eL;
        this.class18_0.class13_u_0.long_237 = 0x6154L;
        this.class18_0.class13_u_0.long_239 = 0x6114L;
        this.class18_0.class13_u_0.long_240 = 0x6115L;
        this.class18_0.class13_u_0.long_241 = 0x6231L;
        this.class18_0.class13_u_0.long_242 = 0x60ecL;
        this.class18_0.class13_u_0.long_243 = 0x6233L;
        this.class18_0.class13_u_0.long_244 = 0x6234L;
        this.class18_0.class13_u_0.long_245 = 0x6791L;
        this.class18_0.class13_u_0.long_246 = 0x628dL;
        this.class18_0.class13_u_0.long_247 = 0x628eL;
        this.class18_0.class13_u_0.long_248 = 0x628fL;
        this.class18_0.class13_u_0.long_249 = 0x6290L;
        this.class18_0.class13_u_0.long_251 = 0x6295L;
        this.class18_0.class13_u_0.long_253 = 0x6292L;
        this.class18_0.class13_u_0.long_254 = 0x6294L;
        this.class18_0.class13_u_0.long_255 = 0x6293L;
        this.class18_0.class13_u_0.long_256 = 0x618aL;
        this.class18_0.class13_u_0.long_257 = 0x62a8L;
        this.class18_0.class13_u_0.long_258 = 0x629cL;
        this.class18_0.class13_u_0.long_259 = 0x62a2L;
        this.class18_0.class13_u_0.long_260 = 0x61c2L;
        this.class18_0.class13_u_0.long_261 = 0x61acL;
        this.class18_0.class13_u_0.long_262 = 0x6196L;
        this.class18_0.class13_u_0.long_263 = 0x61d8L;
        this.class18_0.class13_u_0.long_264 = 0x6154L;
        this.class18_0.class13_u_0.long_265 = 0x610cL;
        this.class18_0.class13_u_0.long_266 = 0x6148L;
        this.class18_0.class13_u_0.long_267 = 0x62b6L;
        this.class18_0.class13_u_0.long_268 = 0x6116L;
        this.class18_0.class13_u_0.long_269 = 0x6150L;
        this.class18_0.class13_u_0.long_270 = 0x6104L;
        this.class18_0.class13_u_0.long_271 = 0x62b8L;
        this.class18_0.class13_u_0.long_272 = 0x6299L;
        this.class18_0.class13_u_0.long_273 = 0x6298L;
        this.class18_0.class13_u_0.long_274 = 0x6297L;
        this.class18_0.class13_u_0.long_275 = 0x629aL;
        this.class18_0.class13_u_0.long_276 = 0x629bL;
        this.class18_0.class13_u_0.long_277 = 0x62b5L;
        this.class18_0.class13_u_0.long_279 = 0x62b4L;
        this.class18_0.class13_u_0.long_280 = 0x6278L;
        this.class18_0.class13_u_0.long_281 = 0x6279L;
        this.class18_0.class13_u_0.long_282 = 0x62b9L;
        this.class18_0.class13_u_0.long_283 = 0x62baL;
        this.class18_0.class13_u_0.long_284 = 0x62bbL;
        this.class18_0.class13_u_0.long_285 = 0x62bdL;
        this.class18_0.class13_u_0.long_286 = 0x62bcL;
        this.class18_0.class13_u_0.long_287 = 0x62c2L;
        this.class18_0.class13_u_0.long_288 = 0x62c1L;
        this.class18_0.class13_u_0.long_289 = 0x62c0L;
        this.class18_0.class13_u_0.long_290 = 0x62bfL;
        this.class18_0.class13_u_0.long_291 = 0x62c7L;
        this.class18_0.class13_u_0.long_292 = 0x62caL;
        this.class18_0.class13_u_0.long_293 = 0x62cbL;
        this.class18_0.class13_u_0.long_294 = 0x62c8L;
        this.class18_0.class13_u_0.long_295 = 0x62c9L;
        this.class18_0.class13_u_0.long_296 = 0x62cdL;
        this.class18_0.class13_u_0.long_297 = 0x62ccL;
        this.class18_0.class13_u_0.long_298 = 0x62ceL;
        this.class18_0.class13_u_0.long_299 = 0x62cfL;
        this.class18_0.class13_u_0.long_300 = 0x62d1L;
        this.class18_0.class13_u_0.long_301 = 0x62d3L;
        this.class18_0.class13_u_0.long_302 = 0x62d4L;
        this.class18_0.class13_u_0.long_303 = 0x62d5L;
        this.class18_0.class13_u_0.long_304 = 0x62d6L;
        this.class18_0.class13_u_0.long_305 = 0x62d7L;
        this.class18_0.class13_u_0.long_306 = 0x62d8L;
        this.class18_0.class13_u_0.long_307 = 0x62d9L;
        this.class18_0.class13_u_0.long_308 = 0x62dbL;
        this.class18_0.class13_u_0.long_309 = 0x62daL;
        this.class18_0.class13_u_0.long_310 = 0x61e2L;
        this.class18_0.class13_u_0.long_311 = 0x61f8L;
        this.class18_0.class13_u_0.long_313 = 0x6158L;
        this.class18_0.class13_u_0.long_314 = 0x615bL;
        this.class18_0.class13_u_0.long_315 = 0x615cL;
        this.class18_0.class13_u_0.long_316 = 0x6159L;
        this.class18_0.class13_u_0.long_317 = 0x615aL;
        this.class18_0.class13_u_0.long_318 = 0x615eL;
        this.class18_0.class13_u_0.long_319 = 0x615dL;
        this.class18_0.class13_u_0.long_320 = 0x615fL;
        this.class18_0.class13_u_0.long_321 = 0x6160L;
        this.class18_0.class13_u_0.long_322 = 0x6162L;
        this.class18_0.class13_u_0.long_323 = 0x6164L;
        this.class18_0.class13_u_0.long_324 = 0x6165L;
        this.class18_0.class13_u_0.long_325 = 0x6166L;
        this.class18_0.class13_u_0.long_326 = 0x6167L;
        this.class18_0.class13_u_0.long_327 = 0x6168L;
        this.class18_0.class13_u_0.long_328 = 0x6169L;
        this.class18_0.class13_u_0.long_329 = 0x616aL;
        this.class18_0.class13_u_0.long_330 = 0x616cL;
        this.class18_0.class13_u_0.long_331 = 0x616bL;
        this.class18_0.class13_u_0.long_332 = 0x6219L;
        this.class18_0.class13_u_0.long_333 = 0x622fL;
        this.class18_0.class13_u_0.long_335 = 0x616dL;
        this.class18_0.class13_u_0.long_336 = 0x6170L;
        this.class18_0.class13_u_0.long_337 = 0x6171L;
        this.class18_0.class13_u_0.long_338 = 0x616eL;
        this.class18_0.class13_u_0.long_339 = 0x616fL;
        this.class18_0.class13_u_0.long_340 = 0x6173L;
        this.class18_0.class13_u_0.long_341 = 0x6172L;
        this.class18_0.class13_u_0.long_342 = 0x6174L;
        this.class18_0.class13_u_0.long_343 = 0x6175L;
        this.class18_0.class13_u_0.long_344 = 0x6177L;
        this.class18_0.class13_u_0.long_345 = 0x6179L;
        this.class18_0.class13_u_0.long_346 = 0x617aL;
        this.class18_0.class13_u_0.long_347 = 0x617bL;
        this.class18_0.class13_u_0.long_348 = 0x617cL;
        this.class18_0.class13_u_0.long_349 = 0x617dL;
        this.class18_0.class13_u_0.long_350 = 0x617eL;
        this.class18_0.class13_u_0.long_351 = 0x617fL;
        this.class18_0.class13_u_0.long_352 = 0x6181L;
        this.class18_0.class13_u_0.long_353 = 0x6180L;
        this.class18_0.class13_u_0.long_354 = 0x61e2L;
        this.class18_0.class13_u_0.long_355 = 0x61f8L;
        this.class18_0.class13_u_0.long_357 = 0x62ddL;
        this.class18_0.class13_u_0.long_358 = 0x62deL;
        this.class18_0.class13_u_0.long_359 = 0x62dfL;
        this.class18_0.class13_u_0.long_360 = 0x62e0L;
        this.class18_0.class13_u_0.long_361 = 0x62e1L;
        this.class18_0.class13_u_0.long_362 = 0x62e3L;
        this.class18_0.class13_u_0.long_363 = 0x62e4L;
        this.class18_0.class13_u_0.long_364 = 0x62e5L;
        this.class18_0.class13_u_0.long_365 = 0x62e8L;
        this.class18_0.class13_u_0.long_366 = 0x62e6L;
        this.class18_0.class13_u_0.long_367 = 0x62e9L;
        this.class18_0.class13_u_0.long_368 = 0x62e7L;
        this.class18_0.class13_u_0.long_369 = 0x62eaL;
        this.class18_0.class13_u_0.long_370 = 0x614dL;
        this.class18_0.class13_u_0.long_371 = 0x614eL;
        this.class18_0.class13_u_0.long_372 = 0x614fL;
        this.class18_0.class13_u_0.long_373 = 0x6149L;
        this.class18_0.class13_u_0.long_377 = 0x60fcL; //lean protect min rpm
        this.class18_0.class13_u_0.long_378 = 0x60feL; //lean protect min tps
        this.class18_0.class13_u_0.long_379 = 0x6100L; //lean protect
        this.class18_0.class13_u_0.long_380 = 0x60ffL; //lean protect
        this.class18_0.class13_u_0.long_381 = 0x6101L; //lean protect
        this.class18_0.class13_u_0.long_382 = 0x6102L; //lean protect
        this.class18_0.class13_u_0.long_383 = 0x6151L; //lean protect
        this.class18_0.class13_u_0.long_384 = 0x6103L; //lean protect
        this.class18_0.class13_u_0.long_385 = 0x6152L; //lean protect
        this.class18_0.class13_u_0.long_386 = 0x6153L; //lean protect
        this.class18_0.class13_u_0.long_390 = 0x645bL;      //closeloop rate of change
        this.class18_0.class13_u_0.long_391 = 0x6333L;      //injector phase
        this.class18_0.class13_u_0.long_402 = 0x60d0L;     //FTS Speed
        this.class18_0.class13_u_0.long_420 = 0x62f5L;     //ignition cut delay
        this.class18_0.class13_u_0.long_421 = 0x6301L;     //Ignition Cut Delay (FTL - Launch)
        this.class18_0.class13_u_0.long_422 = 0x6302L;     //Ignition Cut Delay (FTS)
        this.class18_0.class13_u_0.long_423 = 0x6303L;     //Ignition Cut Fuel Adding
        this.class18_0.class13_u_0.long_424 = 0x6305L;     //Ignition Cut Ign retarding
        this.class18_0.class13_u_0.long_430 = 0x62f6L;     //acs input
        this.class18_0.class13_u_0.long_431 = 0x62f7L;     //psp input
        this.class18_0.class13_u_0.long_432 = 0x62f8L;     //scs input
        this.class18_0.class13_u_0.long_433 = 0x62f9L;     //bkws input
        this.class18_0.class13_u_0.long_434 = 0x62faL;     //vtp input
        this.class18_0.class13_u_0.long_438 = 0x62feL;     //locking rpm
        this.class18_0.class13_u_0.long_439 = 0x6300L;     //antitheft enabled
        this.class18_0.class13_u_0.long_440 = 0x6301L;     //FTS strain cut active
        this.class18_0.class13_u_0.long_450 = 0x6410L;     //injector rate of decay1
        this.class18_0.class13_u_0.long_451 = 0x6418L;     //injector rate of decay2
        this.class18_0.class13_u_0.long_452 = 0x6420L;     //injector rate of decay3
        this.class18_0.class13_u_0.long_453 = 0x6614L;     //crank fuel RPM Compensation
        this.class18_0.class13_u_0.long_454 = 0x6618L;     //crank fuel MAP Compensation
        this.class18_0.class13_u_0.long_460 = 0x60b9L;     //FlexFuel Ethanol Content
        this.class18_0.class13_u_0.long_461 = 0x60a7L;     //FlexFuel Fuel - Closeloop
        this.class18_0.class13_u_0.long_464 = 0x60c1L;     //FlexFuel Ignition - Closeloop
        this.class18_0.class13_u_0.long_466 = 0x62fbL;     //FlexFuel Input
        this.class18_0.class13_u_0.long_472 = 0x6307L;     //FTS Ign Mode (Static or vise versa)
        this.class18_0.class13_u_0.long_473 = 0x6306L;     //FTS Static Ignition Value
        this.class18_0.class13_u_0.long_474 = 0x6308L;     //Fan Cutout Speed
        this.class18_0.class13_u_0.long_475 = 0x6309L;     //AC Cutout Speed
        this.class18_0.class13_u_0.long_482 = 0x661cL;     //Overrun Fuel resume (initial)   hondata 4f4b
        this.class18_0.class13_u_0.long_483 = 0x662aL;     //Overrun Fuel resume (normal)   hondata 4f59
        this.class18_0.class13_u_0.long_484 = 0x6559L;     //Tip-In Fuel (initial)   hondata 4ea6
        this.class18_0.class13_u_0.long_485 = 0x6547L;     //Tip-In Fuel (normal)   hondata 4e94
        this.class18_0.class13_u_0.long_494 = 0x60a6L;     //Ign Cut Mod (With fuel/ign mod or not)
        this.class18_0.class13_u_0.long_4Inj = 0x62c6L;


        this.class18_0.class13_u_0.long_89 = 0x6076L;      //Calibration Area (previous: 0x5f28L; ectune: 0x5f44L)
        this.class18_0.class13_u_0.long_493 = 0x60a5L;     //Ign Cut Mod (With time millisecond mod or not)
        this.class18_0.class13_u_0.long_463 = 0x6091L;     //FlexFuel Fuel - Cranking

        this.class18_0.class13_u_0.long_512 = 0x62fcL;     //FlexFuel Input

        this.class18_0.class13_u_0.long_510 = 0x60b9L; //long_324 in HTS used in knock
        this.class18_0.class13_u_0.long_511 = 0x60a7L; //long_325 in HTS used in knock
        this.class18_0.class13_u_0.long_512 = 0x62fcL; //long_326 in HTS used in knock
        this.class18_0.class13_u_0.long_513 = 0x60a7L; //long_327 in HTS used in knock
        this.class18_0.class13_u_0.long_514 = 0x60c1L; //long_328 in HTS  ** Used in flex Fuel !!!!! **


        this.class18_0.class13_u_0.long_520 = 0x60a4L;   //rev limiter cutting type
        this.class18_0.class13_u_0.long_521 = 0x60a3L;   //enable CPR on ALTC
        //this.class18_0.class13_u_0.long_522 = 0x0175L;   //CPR fully sync when cranking     //should reload
        //this.class18_0.class13_u_0.long_523 = 0x1508L;   //CPR dont fire before sync        //should reload

        this.class18_0.class13_u_0.long_525 = 0x60e6L;   //enable MIL on Ignition Cut
    }

    //#####################################################################################################################################################
    //#####################################################################################################################################################
    //#####################################################################################################################################################
    //#####################################################################################################################################################
    //#####################################################################################################################################################
    //#####################################################################################################################################################

    /*public void ConvertBaserom()
    {
        System.Reflection.FieldInfo[] TestInfo = class13_u_0.GetType().GetFields();
        foreach (FieldInfo property in TestInfo)
        {
            Console.WriteLine(property.GetValue(this).ToString());
        }

    }

    private void LoadLocationsSizes()
    {
        Class13_u class2 = new Class13_u
        {
            long_6 = 24L,     //0x6e59L     **This table dont change location**
            long_8 = 20L,     //0x6e71L     **This table dont change location**
            long_9 = 20L,     //0x6e85L     **This table dont change location**
            long_10 = 504L,     //0x6eadL     **This table dont change location**
            long_11 = 142L,     //0x70a5L     **This table dont change location**

            long_12 = 93L,     //0x729dL     **This table dont change location**
            long_13 = 120L,     //0x747dL     **This table dont change location**
            long_16 = 20L,     //0x6e2fL     **This table dont change location**
            long_17 = 22L,     //0x6e43L     **This table dont change location**
            long_18 = 24L,     //0x6e17L     **This table dont change location**
            long_20 = 504L,     //0x765fL     **This table dont change location**
            long_21 = 504L,     //0x7857L     **This table dont change location**

            long_22 = 480L,     //0x7a4fL     **This table dont change location**
            long_23 = 480L,     //0x7c2fL     **This table dont change location**
            long_24 = 1L,     //0x61a6L
            long_25 = 2L,     //0x61a8L
            long_29 = 20L,     //0x6e99L     **This table dont change location**
            long_31 = 1L,     //0x610fL

            long_32 = 1L,     //0x6110L
            long_33 = 2L,     //0x6101L
            long_34 = 2L,     //0x610dL
            long_35 = 2L,     //0x6103L
            long_36 = 2L,     //0x6105L
            long_37 = 2L,     //0x6107L
            long_38 = 2L,     //0x6109L
            long_39 = 2L,     //0x610bL

            long_43 = 1L,     //0x5f4eL
            long_44 = 1L,     //0x5f4aL
            long_46 = 1L,     //0x5ffdL
            long_47 = 1L,     //0x61f3L
            long_48 = 1L,     //0x620eL
            long_49 = 1L,     //0x61f4L
            long_50 = 1L,     //0x61f5L
            long_51 = 1L,     //0x61f9L

            long_53 = 1L,     //0x61f6L
            long_54 = 1L,     //0x5f4dL
            long_55 = 1L,     //0x5f49L
            long_56 = 1L,     //0x61f7L
            long_58 = 1L,     //0x5ffeL
            long_59 = 1L,     //0x5f46L
            long_60 = 1L,     //0x5f42L
            long_61 = 1L,     //0x5f41L

            long_62 = 1L,     //0x5f43L
            long_63 = 8L,     //0x664fL     **This table dont change location**
            long_65 = 1L,     //0x61f8L
            long_66 = 1L,     //0x620bL
            long_67 = 1L,     //0x620aL
            long_71 = 1L,     //0x6125L

            long_72 = 1L,     //0x6126L
            long_76 = 1L,     //0x616fL
            long_77 = 1L,     //0x619aL
            long_78 = 1L,     //0x61a7L
            long_79 = 1L,     //0x5ffcL
            long_80 = 1L,     //0x61ceL

            long_83 = 13L,     //0x5f8fL
            long_85 = 1L,     //0x5f9cL
            long_88 = 1L,     //0x5f4fL
            long_89 = 2L,     //0x5f44L

            long_95 = 1L,     //0x61d8L
            long_100 = 1L,     //0x61fdL
            long_101 = 1L,     //0x6202L

            long_103 = 1L,     //0x616bL
            long_104 = 1L,     //0x616cL
            long_105 = 1L,     //0x616dL
            long_106 = 1L,     //0x616eL
            long_110 = 1L,     //0x616fL
            long_111 = 1L,     //0x61bfL

            long_112 = 1L,     //0x6200L
            long_113 = 6L,     //0x6203L
            long_114 = 1L,     //0x6138L
            long_115 = 1L,     //0x6139L
            long_116 = 1L,     //0x5f50L
            long_117 = 1L,     //0x6142L
            long_118 = 1L,     //0x6143L
            long_119 = 12L,     //0x6144L
            long_121 = 2L,     //0x613eL

            long_122 = 2L,     //0x6140L
            long_123 = 1L,     //0x613aL
            long_124 = 2L,     //0x613bL
            long_125 = 1L,     //0x613dL
            long_126 = 1L,     //0x6150L
            long_127 = 1L,     //0x6151L
            long_128 = 1L,     //0x615eL
            long_129 = 1L,     //0x615fL
            long_130 = 1L,     //0x615dL
            long_131 = 1L,     //0x619bL

            long_132 = 1L,     //0x5ffbL
            long_133 = 1L,     //0x5ffaL
            long_135 = 4L,     //0x5f77L
            long_136 = 2L,     //0x5fa5L
            long_137 = 1L,     //0x6152L
            long_138 = 1L,     //0x6153L
            long_139 = 1L,     //0x6155L
            long_140 = 2L,     //0x6156L
            long_141 = 1L,     //0x6158L

            long_142 = 5L,     //0x61cfL
            long_143 = 2L,     //0x6165L
            long_144 = 1L,     //0x6154L
            long_147 = 1L,     //0x6159L
            long_148 = 1L,     //0x615aL
            long_149 = 1L,     //0x615bL
            long_150 = 12L,     //0x5f80L
            long_151 = 1L,     //0x5f7eL

            long_152 = 1L,     //0x5f7fL
            long_153 = 1L,     //0x5f59L
            long_154 = 1L,     //0x5f58L
            long_155 = 2L,     //0x5f56L
            long_156 = 1L,     //0x5f55L
            long_157 = 1L,     //0x6164L
            long_158 = 1L,     //0x6160L
            long_159 = 2L,     //0x6161L
            long_160 = 1L,     //0x6163L

            long_162 = 2L,     //0x5f8dL
            long_163 = 1L,     //0x5f8cL
            long_171 = 1L,     //0x5f54L

            long_172 = 1L,     //0x5f53L
            long_173 = 2L,     //0x5f51L
            long_174 = 27L,     //0x62a2L     **This table dont change location**
            long_175 = 24L,     //0x6ab6L     **This table dont change location**
            long_176 = 72L,     //0x622eL     **This table dont change location**
            long_177 = 28L,     //0x6a96L     **This table dont change location**
            long_178 = 27L,     //0x630bL     **This table dont change location**
            long_179 = 27L,     //0x6518L     **This table dont change location**
            long_180 = 1L,     //0x611bL
            long_181 = 1L,     //0x611cL

            long_183 = 4L,     //0x6426L     **This table dont change location**
            long_184 = 1L,     //0x6134L
            long_185 = 24L,     //0x6442L     **This table dont change location**
            long_186 = 6L,     //0x6128L
            long_187 = 6L,     //0x612eL
            long_188 = 1L,     //0x6127L
            long_189 = 2L,     //0x5f44L
            long_190 = 12L,     //0x63b2L     **This table dont change location**
            long_191 = 16L,     //0x6aecL     **This table dont change location**

            long_192 = 1L,     //0x5f9dL
            long_193 = 7L,     //0x5f9eL
                                //long_194 = 4L,     //0x649cL     **This table dont change location**
            long_201 = 42L,     //0x6b7dL     **This table dont change location**

            long_202 = 6L,     //0x6b77L     **This table dont change location**
            long_203 = 8L,     //0x6ba7L     **This table dont change location**
            long_204 = 13L,     //0x6b6aL     **This table dont change location**
            long_205 = 14L,     //0x6b5cL     **This table dont change location**
            long_206 = 1L,     //0x6111L
            long_207 = 1L,     //0x6112L
            long_208 = 1L,     //0x6113L
            long_209 = 12L,     //0x63caL     **This table dont change location**
            long_210 = 12L,     //0x63beL     **This table dont change location**
            long_211 = 2L,     //0x6167L

            long_212 = 2L,     //0x6169L
            long_213 = 2L,     //0x61d5L
            long_215 = 1L,     //0x61d7L
            long_216 = 1L,     //0x61d4L
            long_217 = 1L,     //0x5f5aL
            long_218 = 1L,     //0x61f2L
            long_219 = 1L,     //0x6209L
            long_220 = 1L,     //0x611fL
            long_221 = 52L,     //0x6657L     **This table dont change location**

            long_223 = 1L,     //0x611eL
            long_224 = 1L,     //0x6123L
            long_225 = 1L,     //0x6124L
            long_227 = 1L,     //0x6121L
            long_228 = 1L,     //0x6120L
            long_229 = 1L,     //0x6122L
            long_230 = 1L,     //0x611dL
            long_231 = 1L,     //0x5f7bL

            long_232 = 1L,     //0x5f7cL
            long_233 = 1L,     //0x5f7dL
            long_234 = 1L,     //0x6215L     **This table dont change location**
            long_235 = 1L,     //0x6119L
            long_236 = 1L,     //0x6201L
            long_237 = 4L,     //0x5fc9L
            long_239 = 1L,     //0x5f73L
            long_240 = 1L,     //0x5f74L
            long_241 = 2L,     //0x6114L

            long_242 = 2L,     //0x5f4bL
            long_243 = 1L,     //0x6116L
            long_244 = 2L,     //0x6117L
            long_245 = 42L,     //0x6738L     **This table dont change location**
            long_246 = 1L,     //0x6170L
            long_247 = 1L,     //0x6171L
            long_248 = 1L,     //0x6172L
            long_249 = 2L,     //0x6173L
            long_251 = 2L,     //0x6178L

            long_253 = 1L,     //0x6175L
            long_254 = 1L,     //0x6177L
            long_255 = 1L,     //0x6176L
            long_256 = 12L,     //0x5fffL
            long_257 = 12L,     //0x618bL
            long_258 = 6L,     //0x617fL
            long_259 = 6L,     //0x6185L
            long_260 = 22L,     //0x6037L
            long_261 = 22L,     //0x6021L

            long_262 = 22L,     //0x600bL
            long_263 = 10L,     //0x604dL
            long_264 = 22L,     //0x5fb3L
            long_265 = 8L,     //0x5f6bL
            long_266 = 1L,     //0x5fa7L
            long_267 = 1L,     //0x6199L
            long_268 = 2L,     //0x5f75L
            long_269 = 1L,     //0x5fafL
            long_270 = 8L,     //0x5f63L
            long_271 = 1L,     //0x619bL

            long_272 = 1L,     //0x617cL
            long_273 = 1L,     //0x617bL
            long_274 = 1L,     //0x617aL
            long_275 = 1L,     //0x617dL
            long_276 = 1L,     //0x617eL
            long_277 = 1L,     //0x6198L
            long_279 = 1L,     //0x6197L
            long_280 = 1L,     //0x615bL
            long_281 = 1L,     //0x615cL

            long_282 = 1L,     //0x619cL
            long_283 = 1L,     //0x619dL
            long_284 = 1L,     //0x619eL
            long_285 = 2L,     //0x61a0L
            long_286 = 1L,     //0x619fL
            long_287 = 1L,     //0x61a5L
            long_288 = 1L,     //0x61a4L
            long_289 = 1L,     //0x61a3L
            long_290 = 1L,     //0x61a2L
            long_291 = 1L,     //0x61aaL

            long_292 = 1L,     //0x61adL
            long_293 = 1L,     //0x61aeL
            long_294 = 1L,     //0x61abL
            long_295 = 1L,     //0x61acL
            long_296 = 1L,     //0x61b0L
            long_297 = 1L,     //0x61afL
            long_298 = 1L,     //0x61b1L
            long_299 = 2L,     //0x61b2L
            long_300 = 2L,     //0x61b4L
            long_301 = 1L,     //0x61b6L

            long_302 = 1L,     //0x61b7L
            long_303 = 1L,     //0x61b8L
            long_304 = 1L,     //0x61b9L
            long_305 = 1L,     //0x61baL
            long_306 = 1L,     //0x61bbL
            long_307 = 1L,     //0x61bcL
            long_308 = 1L,     //0x61beL
            long_309 = 1L,     //0x61bdL
            long_310 = 22L,     //0x6057L
            long_311 = 33L,     //0x606dL

            long_313 = 1L,     //0x5fcdL
            long_314 = 1L,     //0x5fd0L
            long_315 = 1L,     //0x5fd1L
            long_316 = 1L,     //0x5fceL
            long_317 = 1L,     //0x5fcfL
            long_318 = 1L,     //0x5fd3L
            long_319 = 1L,     //0x5fd2L
            long_320 = 1L,     //0x5fd4L
            long_321 = 2L,     //0x5fd5L

            long_322 = 2L,     //0x5fd7L
            long_323 = 1L,     //0x5fd9L
            long_324 = 1L,     //0x5fdaL
            long_325 = 1L,     //0x5fdbL
            long_326 = 1L,     //0x5fdcL
            long_327 = 1L,     //0x5fddL
            long_328 = 1L,     //0x5fdeL
            long_329 = 1L,     //0x5fdfL
            long_330 = 1L,     //0x5fe1L
            long_331 = 1L,     //0x5fe0L

            long_332 = 22L,     //0x608eL
            long_333 = 33L,     //0x60a4L
            long_335 = 1L,     //0x5fe2L
            long_336 = 1L,     //0x5fe5L
            long_337 = 1L,     //0x5fe6L
            long_338 = 1L,     //0x5fe3L
            long_339 = 1L,     //0x5fe4L
            long_340 = 1L,     //0x5fe8L
            long_341 = 1L,     //0x5fe7L

            long_342 = 1L,     //0x5fe9L
            long_343 = 2L,     //0x5feaL
            long_344 = 2L,     //0x5fecL
            long_345 = 1L,     //0x5feeL
            long_346 = 1L,     //0x5fefL
            long_347 = 1L,     //0x5ff0L
            long_348 = 1L,     //0x5ff1L
            long_349 = 1L,     //0x5ff2L
            long_350 = 1L,     //0x5ff3L
            long_351 = 1L,     //0x5ff4L

            long_352 = 1L,     //0x5ff6L
            long_353 = 1L,     //0x5ff5L
            long_354 = 22L,     //0x60c5L
            long_355 = 38L,     //0x60dbL
            long_357 = 1L,     //0x61c0L
            long_358 = 1L,     //0x61c1L
            long_359 = 1L,     //0x61c2L
            long_360 = 1L,     //0x61c3L
            long_361 = 2L,     //0x61c4L

            long_362 = 1L,     //0x61c6L
            long_363 = 1L,     //0x61c7L
            long_364 = 1L,     //0x61c8L
            long_365 = 1L,     //0x61cbL
            long_366 = 1L,     //0x61c9L
            long_367 = 1L,     //0x61ccL
            long_368 = 1L,     //0x61caL
            long_369 = 1L,     //0x61cdL
            long_370 = 1L,     //0x5facL
            long_371 = 1L,     //0x5fadL

            long_372 = 1L,     //0x5faeL
            long_373 = 4L,     //0x5fa8L
            long_374 = 14L,     //0x6a7aL     **This table dont change location**
            long_375 = 16L,     //0x6a56L     **This table dont change location**
            long_376 = 20L,     //0x6a66L     **This table dont change location**
            long_377 = 2L,     //0x5f5bL
            long_378 = 1L,     //0x5f5dL
            long_379 = 1L,     //0x5f5fL
            long_380 = 1L,     //0x5f5eL
            long_381 = 1L,     //0x5f60L

            long_382 = 1L,     //0x5f61L
            long_383 = 1L,     //0x5fb0L
            long_384 = 1L,     //0x5f62L
            long_385 = 1L,     //0x5fb1L
            long_386 = 1L,     //0x5fb2L
            long_390 = 24L,     //0x633eL     **This table dont change location**
            long_391 = 6L,     //0x6216L     **This table dont change location**

            long_420 = 1L,     //0x61d8L
            long_421 = 1L,     //0x61e4L

            long_422 = 1L,     //0x61e5L
            long_423 = 2L,     //0x61e6L
            long_424 = 1L,     //0x61e8L
            long_430 = 1L,     //0x61d9L
            long_431 = 1L,     //0x61daL

            long_432 = 1L,     //0x61dbL
            long_433 = 1L,     //0x61dcL
            long_434 = 4L,     //0x61ddL
            long_438 = 2L,     //0x61e1L
            long_439 = 1L,     //0x61e3L
            long_440 = 1L,     //0x61e4L

            long_450 = 8L,     //0x62f3L     **This table dont change location**
            long_451 = 8L,     //0x62fbL     **This table dont change location**

            long_452 = 8L,     //0x6303L     **This table dont change location**
            long_453 = 4L,     //0x6533L     **This table dont change location**
            long_454 = 4L,     //0x6537L     **This table dont change location**

            //long_471 = 1L,     //0x61e8L
            long_472 = 1L,     //0x61eaL
            long_473 = 1L,     //0x61e9L
            long_474 = 1L,     //0x61ebL
            long_475 = 5L,     //0x61ecL
            long_480 = 35L,     //0x6afcL     **This table dont change location**
            long_481 = 16L,     //0x6aecL     **This table dont change location**

            long_482 = 14L,     //0x653bL     **This table dont change location**
            long_483 = 42L,     //0x6549L     **This table dont change location**
            long_484 = 30L,     //0x646cL     **This table dont change location**
            long_485 = 18L,     //0x645aL     **This table dont change location**


            long_4Inj = 0x61a9L,
            long_4PASS = 0x5ea6L    //0x5ea6L     **This table dont change location**
        };
        this.class18_0.class13_0_Sizes = class2;
    }*/

}

