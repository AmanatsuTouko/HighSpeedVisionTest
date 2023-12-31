﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gaming Districtのノーツ情報1
public class NotesData01_1 : MonoBehaviour
{
    //ノーツの情報を入れる配列{生成する時間(μs),向き(1~4),位置(1~4)}
    //1:上, 2:下, 3:左, 4:右
    //https://gametukurikata.com/csharp/jaggedarray
    public static int[,] NotesData = {
    //1--------------------
        {1192000, 1, 1},
        //{1307384, 4, 1},
        //{1422769, 4, 1},
        //{1538153, 4, 1},
    //2--------------------
        {1653538, 3, 3},
        //{1768923, 4, 1},
        //{1884307, 4, 1},
        //{1999692, 4, 1},
    //3--------------------
        {2115077, 2, 2},
        //{2230461, 4, 1},
        //{2345846, 4, 1},
        //{2461230, 4, 1},
    //4--------------------
        {2576615, 4, 4},
        //{2691999, 4, 1},
        //{2807384, 4, 1},
        //{2922768, 4, 1},
    //5--------------------
        {3038153, 1, 1},
        //{3153537, 4, 1},
        //{3268922, 4, 1},
        //{3384307, 4, 1},
    //6--------------------
        {3499691, 3, 3},
        //{3615076, 4, 1},
        //{3730460, 4, 1},
        //{3845845, 4, 1},
    //7--------------------
        {3961229, 2, 2},
        //{4076614, 4, 1},
        //{4191998, 4, 1},
        //{4307383, 4, 1},
    //8--------------------○
        {4422768, 4, 4},
        //{4538153, 4, 1},
        //{4653537, 4, 1},
        //{4768922, 4, 1},
    //9--------------------
        {4884307, 1, 1},
        //{4999692, 4, 1},
        //{5115076, 1, 1},
        //{5230461, 4, 1},
    //10--------------------
        {5345846, 2, 2},
        //{5461231, 4, 1},
        //{5576615, 2, 2},
        //{5692000, 4, 1},
    //11--------------------
        {5807385, 1, 1},
        //{5922770, 4, 1},
        //{6038155, 1, 1},
        //{6153539, 4, 1},
    //12--------------------
        {6268924, 2, 2},
        //{6384309, 4, 1},
        //{6499694, 2, 2},
        //{6615078, 4, 1},
    //13--------------------
        {6730463, 3, 3},
        //{6845848, 1, 1},
        //{6961233, 3, 3},
        //{7076617, 4, 1},
    //14--------------------
        {7192002, 4, 4},
        //{7307387, 3, 3},
        //{7422772, 4, 4},
        //{7538156, 4, 1},
    //15--------------------
        {7653541, 3, 3},
        //{7768926, 2, 2},
        //{7884311, 3, 3},
        //{7999696, 4, 1},
    //16--------------------
        {8115080, 4, 4},
        //{8230465, 4, 4},
        //{8345849, 4, 4},
        //{8461234, 4, 1},
    //17--------------------
        {8576619, 1, 1},
        //{8692004, 1, 1},
        //{8807389, 1, 1},
        //{8922773, 4, 1},
    //18--------------------
        {9038158, 3, 3},
        //{9153543, 3, 3},
        //{9268928, 2, 2},
        //{9384312, 4, 1},
    //19--------------------
        {9499697, 2, 2},
        //{9615082, 2, 2},
        //{9730467, 1, 1},
        //{9845852, 4, 1},
    //20--------------------
        {9961236, 4, 4},
        //{10076621, 4, 4},
        //{10192006, 2, 2},
        //{10307391, 4, 1},
    //21--------------------
        {10422775, 1, 1},
        //{10538160, 1, 1},
        //{10653545, 3, 3},
        //{10768930, 4, 1},
    //22--------------------
        {10884314, 3, 3},
        //{10999699, 3, 3},
        //{11115084, 4, 4},
        //{11230469, 4, 1},
    //23--------------------
        {11345854, 2, 2},
        //{11461238, 2, 2},
        //{11576623, 3, 3},
        //{11692008, 4, 1},
    //24--------------------
        {11807393, 4, 4},
        //{11922777, 4, 4},
        //{12038162, 4, 4},
        //{12153547, 4, 1},
    //25--------------------crash
        {12268932, 1, 1},
        //{12384316, 1, 1},
        {12499701, 1, 1},
        //{12615086, 4, 1},
    //26--------------------
        //{12730471, 4, 4},
        //{12845855, 4, 1},
        {12961240, 1, 1},
        //{13076625, 4, 1},
    //27--------------------
        //{13192010, 4, 1},
        //{13307395, 4, 1},
        {13422779, 4, 4},
        //{13538164, 4, 1},
    //28--------------------
        //{13653549, 3, 3},
        //{13768934, 4, 1},
        {13884318, 4, 4},
        //{13999703, 4, 1},
    //29--------------------
        //{14115088, 4, 1},
        //{14230473, 4, 1},
        {14345857, 2, 2},
        //{14461242, 4, 1},
    //30--------------------
        //{14576627, 4, 4},
        //{14692012, 4, 1},
        {14807396, 2, 2},
        //{14922781, 4, 1},
    //31--------------------
        //{15038166, 4, 1},
        //{15153551, 4, 1},
        {15268936, 3, 3},
        //{15384320, 4, 1},
    //32--------------------
        //{15499705, 3, 3},
        //{15615090, 4, 1},
        {15730475, 3, 3},
        //{15845859, 4, 1},
    //33--------------------
        //{15961244, 4, 1},
        //{16076629, 4, 1},
        {16192014, 4, 4},
        //{16307398, 4, 1},
    //34--------------------
        //{16422783, 4, 1},
        //{16538168, 4, 1},
        {16653553, 3, 3},
        //{16768938, 4, 1},
    //35--------------------
        //{16884322, 4, 1},
        //{16999708, 4, 1},
        {17115092, 4, 4},
        //{17230476, 4, 1},
    //36--------------------
        //{17345862, 4, 1},
        //{17461246, 4, 1},
        {17576630, 3, 3},
        //{17692016, 4, 1},
    //37--------------------
        //{17807400, 4, 1},
        //{17922786, 4, 1},
        {18038170, 2, 2},
        //{18153554, 4, 1},
    //38--------------------
        //{18268940, 4, 1},
        //{18384324, 4, 1},
        {18499708, 1, 1},
        //{18615094, 4, 1},
    //39--------------------
        //{18730478, 4, 1},
        //{18845864, 4, 1},
        {18961248, 2, 2},
        //{19076632, 4, 1},
    //40--------------------
        {19192018, 2, 2},
        //{19307402, 4, 1},
        //{19422788, 4, 1},
        //{19538172, 4, 1},
    //41--------------------8bit in
        {19653556, 1, 1},
        //{19768942, 4, 1},
        //{19884326, 4, 1},
        //{19999710, 4, 1},
    //42--------------------
        {20115096, 1, 1},
        //{20230480, 4, 1},
        //{20345866, 4, 1},
        //{20461250, 4, 1},
    //43--------------------
        {20576634, 3, 3},
        //{20692020, 4, 1},
        //{20807404, 4, 1},
        //{20922790, 4, 1},
    //44--------------------
        {21038174, 3, 3},
        //{21153558, 4, 1},
        //{21268944, 4, 1},
        //{21384328, 4, 1},
    //45--------------------
        {21499712, 1, 1},
        //{21615098, 4, 1},
        //{21730482, 4, 1},
        //{21845868, 4, 1},
    //46--------------------
        {21961252, 1, 1},
        //{22076636, 4, 1},
        //{22192022, 4, 1},
        //{22307406, 4, 1},
    //47--------------------
        {22422792, 3, 3},
        //{22538176, 4, 1},
        //{22653560, 4, 1},
        //{22768946, 4, 1},
    //48--------------------
        //{22884330, 4, 1},
        //{22999714, 4, 1},
        //{23115100, 4, 1},
        //{23230484, 4, 1},
    //49--------------------
        {23345870, 4, 4},
        //{23461254, 4, 1},
        //{23576638, 4, 1},
        //{23692024, 4, 1},
    //50--------------------
        {23807408, 4, 4},
        //{23922792, 4, 1},
        //{24038178, 4, 1},
        //{24153562, 4, 1},
    //51--------------------
        {24268948, 2, 2},
        //{24384332, 4, 1},
        //{24499716, 4, 1},
        //{24615102, 4, 1},
    //52--------------------
        {24730486, 2, 2},
        //{24845872, 4, 1},
        //{24961256, 4, 1},
        //{25076640, 4, 1},
    //53--------------------
        {25192026, 4, 4},
        //{25307410, 4, 1},
        //{25422794, 4, 1},
        //{25538180, 4, 1},
    //54--------------------
        {25653564, 4, 4},
        //{25768950, 4, 1},
        //{25884334, 4, 1},
        //{25999718, 4, 1},
    //55--------------------
        {26115104, 2, 2},
        //{26230488, 4, 1},
        //{26345874, 4, 1},
        //{26461258, 4, 1},
    //56--------------------
        //{26576642, 4, 1},
        //{26692028, 4, 1},
        //{26807412, 4, 1},
        //{26922796, 4, 1},
    //57--------------------repeat
        {27038182, 1, 1},
        //{27153566, 4, 1},
        //{27268952, 4, 1},
        //{27384336, 4, 1},
    //58--------------------
        {27499720, 1, 1},
        //{27615106, 4, 1},
        //{27730490, 4, 1},
        //{27845876, 4, 1},
    //59--------------------
        {27961260, 2, 2},
        //{28076644, 4, 1},
        //{28192030, 4, 1},
        //{28307414, 4, 1},
    //60--------------------
        {28422798, 2, 2},
        //{28538184, 4, 1},
        //{28653568, 4, 1},
        //{28768954, 4, 1},
    //61--------------------
        {28884338, 1, 1},
        //{28999722, 4, 1},
        //{29115108, 4, 1},
        //{29230492, 4, 1},
    //62--------------------
        {29345876, 1, 1},
        //{29461262, 4, 1},
        //{29576646, 4, 1},
        //{29692032, 4, 1},
    //63--------------------
        {29807416, 2, 2},
        //{29922800, 4, 1},
        //{30038186, 4, 1},
        //{30153570, 4, 1},
    //64--------------------
        //{30268956, 4, 4},
        //{30384340, 4, 1},
        //{30499724, 4, 1},
        //{30615110, 4, 1},
    //65--------------------
        {30730494, 4, 4},
        //{30845878, 4, 1},
        //{30961264, 4, 1},
        //{31076648, 4, 1},
    //66--------------------
        {31192034, 4, 4},
        //{31307418, 4, 1},
        //{31422802, 4, 1},
        //{31538188, 4, 1},
    //67--------------------
        {31653572, 3, 3},
        //{31768958, 4, 1},
        //{31884342, 4, 1},
        //{31999726, 4, 1},
    //68--------------------
        {32115112, 3, 3},
        //{32230496, 4, 1},
        //{32345880, 4, 1},
        //{32461266, 4, 1},
    //69--------------------
        {32576650, 4, 4},
        //{32692036, 4, 1},
        //{32807418, 4, 1},
        //{32922800, 4, 1},
    //70--------------------
        {33038184, 4, 4},
        //{33153566, 4, 1},
        //{33268950, 4, 1},
        //{33384332, 4, 1},
    //71--------------------
        {33499714, 3, 3},
        //{33615096, 4, 1},
        //{33730480, 4, 1},
        //{33845864, 4, 1},
    //72--------------------
        //{33961248, 4, 1},
        //{34076628, 4, 1},
        //{34192012, 4, 1},
        //{34307396, 4, 1},
    //73--------------------8bit 後半
        {34422776, 4, 4},
        //{34538160, 4, 1},
        //{34653544, 4, 1},
        //{34768924, 4, 1},
    //74--------------------
        {34884308, 4, 4},
        //{34999692, 4, 1},
        //{35115076, 4, 1},
        //{35230456, 4, 1},
    //75--------------------
        {35345840, 4, 4},
        //{35461224, 4, 1},
        //{35576604, 4, 1},
        //{35691988, 4, 1},
    //76--------------------
        {35807372, 1, 1},
        //{35922752, 4, 1},
        //{36038136, 4, 1},
        //{36153520, 4, 1},
    //77--------------------
        {36268904, 4, 4},
        //{36384284, 4, 1},
        //{36499668, 4, 1},
        //{36615052, 4, 1},
    //78--------------------
        {36730432, 4, 4},
        //{36845816, 4, 1},
        //{36961200, 4, 1},
        //{37076584, 4, 1},
    //79--------------------
        {37191964, 4, 4},
        //{37307348, 4, 1},
        //{37422732, 4, 1},
        //{37538112, 4, 1},
    //80--------------------
        //{37653496, 1, 1},
        //{37768880, 4, 1},
        //{37884260, 4, 1},
        //{37999644, 4, 1},
    //81--------------------
        {38115028, 3, 3},
        //{38230412, 4, 1},
        //{38345792, 4, 1},
        //{38461176, 4, 1},
    //82--------------------
        {38576560, 3, 3},
        //{38691940, 4, 1},
        //{38807324, 4, 1},
        //{38922708, 4, 1},
    //83--------------------
        {39038088, 3, 3},
        //{39153472, 4, 1},
        //{39268856, 4, 1},
        //{39384240, 4, 1},
    //84--------------------
        {39499620, 1, 1},
        //{39615004, 4, 1},
        //{39730388, 4, 1},
        //{39845768, 4, 1},
    //85--------------------
        {39961152, 3, 3},
        //{40076536, 4, 1},
        //{40191916, 4, 1},
        //{40307300, 4, 1},
    //86--------------------
        {40422684, 3, 3},
        //{40538068, 4, 1},
        //{40653448, 4, 1},
        //{40768832, 4, 1},
    //87--------------------
        {40884216, 3, 3},
        //{40999596, 4, 1},
        //{41114980, 4, 1},
        //{41230364, 4, 1},
    //88--------------------
        //{41345748, 4, 1},
        //{41461128, 4, 1},
        //{41576512, 4, 1},
        //{41691896, 4, 1},
    //89--------------------8bit build
        {41807276, 2, 2},
        //{41922660, 4, 1},
        //{42038044, 4, 1},
        //{42153424, 4, 1},
    //90--------------------
        {42268808, 2, 2},
        //{42384192, 4, 1},
        //{42499576, 4, 1},
        //{42614956, 4, 1},
    //91--------------------
        {42730340, 2, 2},
        //{42845724, 4, 1},
        //{42961104, 4, 1},
        //{43076488, 4, 1},
    //92--------------------
        {43191872, 2, 2},
        //{43307252, 4, 1},
        //{43422636, 4, 1},
        //{43538020, 4, 1},
    //93--------------------
        {43653404, 3, 3},
        //{43768784, 4, 1},
        //{43884168, 4, 1},
        //{43999552, 4, 1},
    //94--------------------
        {44114932, 3, 3},
        //{44230316, 4, 1},
        //{44345700, 4, 1},
        //{44461084, 4, 1},
    //95--------------------
        {44576464, 3, 3},
        //{44691848, 4, 1},
        //{44807232, 4, 1},
        //{44922612, 4, 1},
    //96--------------------
        {45037996, 3, 3},
        //{45153380, 4, 1},
        //{45268760, 4, 1},
        //{45384144, 4, 1},
    //97--------------------
        {45499528, 4, 4},
        //{45614912, 4, 1},
        //{45730292, 4, 1},
        //{45845676, 4, 1},
    //98--------------------
        {45961060, 4, 4},
        //{46076440, 4, 1},
        //{46191824, 4, 1},
        //{46307208, 4, 1},
    //99--------------------
        {46422588, 4, 4},
        //{46537972, 4, 1},
        //{46653356, 4, 1},
        //{46768740, 4, 1},
    //100--------------------
        {46884120, 4, 4},
        //{46999504, 4, 1},
        //{47114888, 4, 1},
        //{47230268, 4, 1},
    //101--------------------
        {47345652, 1, 1},
        //{47461036, 4, 1},
        {47576416, 1, 1},
        //{47691800, 4, 1},
    //102--------------------
        {47807184, 1, 1},
        //{47922568, 4, 1},
        {48037948, 1, 1},
        //{48153332, 4, 1},
    //103--------------------
        {48268716, 1, 1},
        {48384096, 1, 1},
        {48499480, 1, 1},
        {48614864, 1, 1},
    //104--------------------
        {48730248, 1, 1},
        //{48845628, 4, 1},
        //{48961012, 4, 1},
        //{49076396, 4, 1},
    //105--------------------シンセ in
        {49191776, 3, 3},
        //{49307160, 4, 1},
        //{49422544, 4, 1},
        {49537924, 3, 3},
    //106--------------------
        //{49653308, 4, 1},
        //{49768692, 4, 1},
        {49884076, 3, 3},
        //{49999456, 4, 1},
    //107--------------------
        //{50114840, 4, 1},
        //{50230224, 4, 1},
        {50345604, 2, 2},
        //{50460988, 4, 1},
    //108--------------------
        {50576372, 2, 2},
        //{50691752, 4, 1},
        {50807136, 2, 2},
        //{50922520, 4, 1},
    //109--------------------
        {51037904, 4, 4},
        //{51153284, 4, 1},
        //{51268668, 4, 1},
        {51384052, 4, 4},
    //110--------------------
        //{51499432, 4, 1},
        //{51614816, 4, 1},
        {51730200, 4, 4},
        //{51845584, 4, 1},
    //111--------------------
        //{51960964, 4, 1},
        //{52076348, 4, 1},
        {52191732, 1, 1},
        //{52307112, 4, 1},
    //112--------------------
        {52422496, 1, 1},
        //{52537880, 4, 1},
        {52653260, 1, 1},
        //{52768644, 4, 1},
    //113--------------------
        {52884028, 1, 1},
        //{52999412, 4, 1},
        //{53114792, 4, 1},
        //{53230176, 4, 1},
    //114--------------------
        //{53345560, 4, 1},
        //{53460940, 4, 1},
        {53576324, 2, 2},
        //{53691708, 4, 1},
    //115--------------------
        //{53807088, 4, 1},
        //{53922472, 4, 1},
        //{54037856, 4, 1},
        //{54153240, 4, 1},
    //116--------------------
        //{54268620, 4, 1},
        //{54384004, 4, 1},
        //{54499388, 4, 1},
        //{54614768, 4, 1},
    //117--------------------
        {54730152, 2, 2},
        //{54845536, 2, 2},
        {54960916, 2, 2},
        //{55076300, 4, 1},
    //118--------------------
        {55191684, 2, 2},
        //{55307068, 4, 1},
        //{55422448, 4, 1},
        //{55537832, 4, 1},
    //119--------------------
        {55653216, 4, 4},
        //{55768596, 4, 1},
        {55883980, 4, 4},
        //{55999364, 4, 1},
    //120--------------------
        {56114748, 4, 4},
        //{56230128, 4, 1},
        //{56345512, 4, 1},
        //{56460896, 4, 1},
    //121--------------------repeat
        {56576276, 3, 3},
        //{56691660, 4, 1},
        //{56807044, 4, 1},
        {56922424, 3, 3},
    //122--------------------
        //{57037808, 4, 1},
        //{57153192, 4, 1},
        {57268576, 3, 3},
        //{57383956, 4, 1},
    //123--------------------
        //{57499340, 4, 1},
        //{57614724, 4, 1},
        {57730104, 2, 2},
        //{57845488, 4, 1},
    //124--------------------
        {57960872, 2, 2},
        //{58076252, 4, 1},
        {58191636, 2, 2},
        //{58307020, 4, 1},
    //125--------------------
        {58422404, 4, 4},
        //{58537784, 4, 1},
        //{58653168, 4, 1},
        {58768552, 4, 4},
    //126--------------------
        //{58883932, 4, 1},
        //{58999316, 4, 1},
        {59114700, 4, 4},
        //{59230084, 4, 1},
    //127--------------------
        //{59345464, 4, 1},
        //{59460848, 4, 1},
        {59576232, 1, 1},
        //{59691612, 4, 1},
    //128--------------------
        {59806996, 1, 1},
        //{59922380, 4, 1},
        {60037760, 1, 1},
        //{60153144, 4, 1},
    //129--------------------
        {60268528, 4, 4},
        //{60383912, 4, 1},
        //{60499292, 4, 1},
        //{60614676, 4, 1},
    //130--------------------
        //{60730060, 4, 1},
        //{60845440, 4, 1},
        //{60960824, 4, 1},
        //{61076208, 4, 1},
    //131--------------------
        //{61191588, 4, 1},
        //{61306972, 4, 1},
        //{61422356, 4, 1},
        //{61537740, 4, 1},
    //132--------------------
        {61653120, 2, 2},
        //{61768504, 4, 1},
        //{61883888, 4, 1},
        //{61999268, 4, 1},
    //133--------------------
        {62114652, 1, 1},
        //{62230036, 4, 1},
        //{62345416, 4, 1},
        //{62460800, 4, 1},
    //134--------------------
        //{62576184, 4, 1},
        //{62691568, 4, 1},
        //{62806948, 4, 1},
        //{62922332, 4, 1},
    //135--------------------
        {63037716, 3, 3},
        //{63153096, 4, 1},
        //{63268480, 4, 1},
        {63383864, 3, 3},
    //136--------------------
        //{63499248, 4, 1},
        //{63614628, 4, 1},
        {63730012, 3, 3},
        {63845396, 3, 3},
    //137--------------------build
        //{63960776, 4, 1},
        //{64076160, 4, 1},
        {64191544, 1, 1},
        //{64306924, 4, 1},
    //138--------------------
        //{64422308, 4, 1},
        //{64537692, 1, 1},
        {64653076, 1, 1},
        //{64768456, 4, 1},
    //139--------------------
        //{64883840, 4, 1},
        //{64999224, 4, 1},
        {65114604, 1, 1},
        //{65229988, 4, 1},
    //140--------------------
        //{65345372, 4, 1},
        //{65460752, 1, 1},
        {65576140, 1, 1},
        //{65691524, 4, 1},
    //141--------------------
        //{65806908, 4, 1},
        //{65922288, 4, 1},
        {66037672, 4, 4},
        //{66153056, 4, 1},
    //142--------------------
        //{66268436, 4, 1},
        {66383820, 4, 4},
        {66499204, 4, 4},
        //{66614584, 4, 1},
    //143--------------------
        {66729968, 2, 2},
        //{66845352, 4, 1},
        //{66960736, 4, 1},
        //{67076116, 4, 1},
    //144--------------------
        {67191504, 2, 2},
        //{67306880, 4, 1},
        //{67422264, 4, 1},
        //{67537648, 4, 1},
    //145--------------------2
        //{67653032, 4, 1},
        //{67768416, 4, 1},
        {67883800, 1, 1},
        //{67999176, 4, 1},
    //146--------------------
        //{68114560, 4, 1},
        //{68229944, 4, 1},
        {68345328, 1, 1},
        //{68460712, 4, 1},
    //147--------------------
        //{68576096, 4, 1},
        //{68691480, 4, 1},
        {68806856, 1, 1},
        //{68922240, 4, 1},
    //148--------------------
        //{69037624, 4, 1},
        //{69153008, 4, 1},
        {69268392, 1, 1},
        //{69383776, 4, 1},
    //149--------------------
        //{69499160, 4, 1},
        //{69614536, 4, 1},
        {69729920, 3, 3},
        //{69845304, 4, 1},
    //150--------------------
        //{69960688, 4, 1},
        {70076072, 3, 3},
        {70191456, 3, 3},
        //{70306832, 4, 1},
    //151--------------------
        {70422216, 2, 2},
        //{70537600, 4, 1},
        //{70652984, 4, 1},
        //{70768368, 4, 1},
    //152--------------------
        {70883752, 2, 2},
        //{70999136, 4, 1},
        //{71114512, 4, 1},
        //{71229896, 4, 1},
    //153--------------------3
        {71345280, 1, 1},
        //{71460664, 4, 1},
        //{71576048, 4, 1},
        //{71691432, 4, 1},
    //154--------------------
        {71806816, 4, 4},
        //{71922192, 4, 1},
        //{72037576, 4, 1},
        //{72152960, 4, 1},
    //155--------------------
        {72268344, 2, 2},
        //{72383728, 4, 1},
        //{72499112, 4, 1},
        //{72614496, 4, 1},
    //156--------------------
        {72729872, 3, 3},
        //{72845256, 4, 1},
        //{72960640, 4, 1},
        //{73076024, 4, 1},
    //157--------------------
        {73191408, 1, 1},
        //{73306792, 4, 1},
        //{73422168, 4, 1},
        //{73537552, 4, 1},
    //158--------------------
        {73652936, 4, 4},
        //{73768320, 4, 1},
        //{73883704, 4, 1},
        //{73999088, 4, 1},
    //159--------------------
        {74114472, 2, 2},
        //{74229848, 4, 1},
        //{74345232, 4, 1},
        //{74460616, 4, 1},
    //160--------------------
        {74576000, 3, 3},
        //{74691384, 4, 1},
        //{74806768, 4, 1},
        //{74922152, 4, 1},
    //161--------------------4
        {75037528, 1, 1},
        //{75152912, 1, 1},
        {75268296, 1, 1},
        //{75383680, 4, 1},
    //162--------------------
        {75499064, 4, 4},
        //{75614448, 4, 1},
        {75729832, 4, 4},
        //{75845208, 4, 1},
    //163--------------------
        {75960592, 2, 2},
        //{76075976, 4, 1},
        {76191360, 2, 2},
        //{76306744, 4, 1},
    //164--------------------
        {76422128, 3, 3},
        //{76537504, 4, 1},
        {76652888, 3, 3},
        //{76768272, 4, 1},
    //165--------------------
        {76883656, 2, 2},
        //{76999040, 4, 1},
        {77114424, 2, 2},
        //{77229808, 4, 1},
    //166--------------------
        {77345184, 2, 2},
        //{77460568, 4, 1},
        {77575952, 2, 2},
        //{77691336, 4, 1},
    //167--------------------
        {77806720, 4, 4},
        {77922104, 4, 4},
        {78037488, 4, 4},
        {78152864, 4, 4},
    //168--------------------
        {78268248, 4, 4},
        {78383632, 4, 4},
        {78499016, 4, 4},
        {78614400, 4, 4},
    //169--------------------drop
        {78729784, 4, 4},
        //{78845168, 4, 1},
        //{78960544, 4, 1},
        //{79075928, 4, 1},
    //170--------------------
        //{79191312, 4, 1},
        //{79306696, 4, 1},
        //{79422080, 4, 1},
        //{79537464, 4, 1},
    //171--------------------
        //{79652840, 4, 1},
        //{79768224, 4, 1},
        //{79883608, 4, 1},
        //{79998992, 4, 1},
    //172--------------------
        //{80114376, 4, 1},
        //{80229760, 4, 1},
        //{80345144, 4, 1},
        //{80460520, 4, 1},
    //173--------------------
        {80575904, 1, 1},
        //{80691288, 4, 1},
        //{80806672, 4, 1},
        //{80922056, 4, 1},
    //174--------------------
        //{81037440, 3, 3},
        //{81152824, 4, 1},
        //{81268200, 4, 1},
        //{81383584, 4, 1},
    //175--------------------
        {81498968, 3, 3},
        //{81614352, 4, 1},
        //{81729736, 3, 3},
        //{81845120, 4, 1},
    //176--------------------
        {81960496, 3, 3},
        //{82075880, 4, 1},
        //{82191264, 4, 1},
        //{82306648, 4, 1},
    //177--------------------
        {82422032, 2, 2},
        //{82537416, 4, 1},
        //{82652800, 4, 4},
        //{82768176, 4, 4},
    //178--------------------
        //{82883560, 4, 1},
        //{82998944, 4, 1},
        {83114328, 4, 4},
        {83229712, 4, 4},
    //179--------------------
        //{83345096, 1, 1},
        //{83460480, 4, 1},
        //{83575856, 4, 1},
        //{83691240, 4, 1},
    //180--------------------
        //{83806624, 4, 1},
        //{83922008, 4, 1},
        //{84037392, 4, 1},
        //{84152776, 4, 1},
    //181--------------------
        {84268160, 1, 1},
        //{84383536, 4, 1},
        //{84498920, 4, 4},
        //{84614304, 4, 1},
    //182--------------------
        //{84729688, 2, 2},
        //{84845072, 4, 1},
        //{84960456, 4, 1},
        //{85075832, 4, 1},
    //183--------------------
        {85191216, 4, 4},
        //{85306600, 4, 1},
        //{85421984, 4, 1},
        //{85537368, 4, 1},
    //184--------------------
        {85652752, 4, 4},
        //{85768136, 4, 1},
        //{85883512, 4, 1},
        //{85998896, 4, 1},
    //185--------------------repeat
        {86114280, 2, 2},
        //{86229664, 4, 1},
        //{86345048, 4, 1},
        //{86460432, 4, 1},
    //186--------------------
        {86575816, 3, 3},
        //{86691192, 4, 1},
        //{86806576, 4, 1},
        //{86921960, 4, 1},
    //187--------------------
        {87037344, 2, 2},
        //{87152728, 4, 1},
        //{87268112, 4, 1},
        //{87383496, 4, 1},
    //188--------------------
        {87498872, 2, 2},
        //{87614256, 4, 1},
        //{87729640, 4, 1},
        //{87845024, 4, 1},
    //189--------------------
        {87960408, 4, 4},
        //{88075792, 4, 1},
        //{88191168, 4, 1},
        //{88306552, 4, 1},
    //190--------------------
        {88421936, 3, 3},
        //{88537320, 4, 1},
        //{88652704, 4, 1},
        //{88768088, 4, 1},
    //191--------------------
        {88883472, 4, 4},
        //{88998848, 4, 1},
        //{89114232, 4, 1},
        //{89229616, 4, 1},
    //192--------------------
        {89345000, 4, 4},
        //{89460384, 4, 1},
        //{89575768, 4, 1},
        //{89691152, 4, 1},
    //193--------------------
        {89806528, 2, 2},
        //{89921912, 4, 1},
        {90037296, 2, 2},
        //{90152680, 4, 1},
    //194--------------------
        {90268064, 2, 2},
        //{90383448, 4, 1},
        {90498832, 2, 2},
        //{90614208, 4, 1},
    //195--------------------
        {90729592, 3, 3},
        //{90844976, 4, 1},
        {90960360, 3, 3},
        //{91075744, 4, 1},
    //196--------------------
        {91191128, 3, 3},
        //{91306504, 4, 1},
        {91421888, 3, 3},
        //{91537272, 4, 1},
    //197--------------------
        {91652656, 1, 1},
        {91768040, 1, 1},
        {91883424, 1, 1},
        {91998808, 1, 1},
    //198--------------------
        {92114184, 1, 1},
        {92229568, 1, 1},
        {92344952, 1, 1},
        {92460336, 1, 1},
    //199--------------------
        {92575720, 4, 4},
        {92691104, 4, 4},
        {92806488, 4, 4},
        {92921864, 4, 4},
    //200--------------------
        {93037248, 4, 4},
        //{93152632, 4, 1},
        //{93268016, 4, 1},
        //{93383400, 4, 1},
    //201--------------------kick
        {93498784, 2, 2},
        //{93614168, 4, 1},
        //{93729544, 4, 1},
        //{93844928, 4, 1},
    //202--------------------
        //{93960312, 4, 1},
        //{94075696, 4, 1},
        //{94191080, 4, 1},
        //{94306464, 4, 1},
    //203--------------------
        //{94421840, 4, 1},
        //{94537224, 4, 1},
        //{94652608, 4, 1},
        //{94767992, 4, 1},
    //204--------------------
        //{94883376, 4, 1},
        //{94998760, 4, 1},
        //{95114144, 4, 1},
        //{95229520, 4, 1},
    //205--------------------
        {95344904, 2, 2},
        //{95460288, 4, 1},
        //{95575672, 4, 1},
        //{95691056, 4, 1},
    //206--------------------
        {95806440, 2, 2},
        //{95921824, 4, 1},
        //{96037200, 4, 1},
        //{96152584, 4, 1},
    //207--------------------
        {96267968, 3, 3},
        //{96383352, 4, 1},
        {96498736, 3, 3},
        //{96614120, 4, 1},
    //208--------------------
        {96729504, 1, 1},
        //{96844880, 4, 1},
        //{96960264, 4, 1},
        //{97075648, 4, 1},
    //209--------------------サビ
        {97191032, 4, 4},
        //{97306416, 4, 1},
        //{97421800, 4, 1},
        //{97537176, 4, 1},
    //210--------------------
        {97652560, 2, 2},
        //{97767944, 4, 1},
        //{97883328, 4, 1},
        //{97998712, 4, 1},
    //211--------------------
        {98114096, 4, 4},
        //{98229480, 4, 1},
        //{98344856, 4, 1},
        {98460240, 4, 4},
    //212--------------------
        //{98575624, 4, 1},
        //{98691008, 4, 1},
        {98806392, 4, 4},
        //{98921776, 4, 1},
    //213--------------------
        {99037160, 3, 3},
        //{99152536, 4, 1},
        //{99267920, 4, 1},
        //{99383304, 4, 1},
    //214--------------------
        {99498688, 2, 2},
        //{99614072, 4, 1},
        //{99729456, 4, 1},
        //{99844832, 4, 1},
    //215--------------------
        {99960216, 3, 3},
        //{100075600, 4, 1},
        //{100190984, 4, 1},
        {100306368, 3, 3},
    //216--------------------
        //{100421752, 4, 1},
        //{100537136, 4, 1},
        {100652512, 3, 3},
        //{100767896, 4, 1},
    //217--------------------
        {100883280, 4, 4},
        //{100998664, 4, 1},
        //{101114048, 4, 1},
        //{101229432, 4, 1},
    //218--------------------
        {101344816, 1, 1},
        //{101460192, 4, 1},
        //{101575576, 4, 1},
        //{101690960, 4, 1},
    //219--------------------
        {101806344, 4, 4},
        //{101921728, 4, 1},
        //{102037112, 4, 1},
        {102152496, 4, 4},
    //220--------------------
        //{102267872, 4, 1},
        //{102383256, 4, 1},
        {102498640, 4, 4},
        //{102614024, 4, 1},
    //221--------------------
        {102729408, 3, 3},
        //{102844792, 4, 1},
        //{102960168, 4, 1},
        //{103075552, 4, 1},
    //222--------------------
        {103190936, 1, 1},
        //{103306320, 4, 1},
        //{103421704, 4, 1},
        //{103537088, 4, 1},
    //223--------------------
        {103652472, 3, 3},
        //{103767848, 4, 1},
        //{103883232, 4, 1},
        {103998616, 3, 3},
    //224--------------------
        //{104114000, 4, 1},
        //{104229384, 4, 1},
        {104344768, 3, 3},
        //{104460152, 4, 1},
    //225--------------------サビ2/4
        {104575528, 1, 1},
        //{104690912, 4, 1},
        //{104806296, 4, 1},
        //{104921680, 4, 1},
    //226--------------------
        {105037064, 4, 4},
        //{105152448, 4, 1},
        //{105267832, 4, 1},
        //{105383208, 4, 1},
    //227--------------------
        {105498592, 1, 1},
        //{105613976, 4, 1},
        //{105729360, 4, 1},
        {105844744, 1, 1},
    //228--------------------
        //{105960128, 4, 1},
        //{106075504, 4, 1},
        {106190888, 1, 1},
        //{106306272, 4, 1},
    //229--------------------
        {106421656, 4, 4},
        //{106537040, 4, 1},
        //{106652424, 4, 1},
        //{106767808, 4, 1},
    //230--------------------
        {106883184, 2, 2},
        //{106998568, 4, 1},
        //{107113952, 4, 1},
        //{107229336, 4, 1},
    //231--------------------
        {107344720, 4, 4},
        //{107460104, 4, 1},
        //{107575488, 4, 1},
        {107690864, 4, 4},
    //232--------------------
        //{107806248, 4, 1},
        //{107921632, 4, 1},
        {108037016, 4, 4},
        //{108152400, 4, 1},
    //233--------------------
        {108267784, 2, 2},
        //{108383168, 4, 1},
        //{108498544, 4, 1},
        //{108613928, 4, 1},
    //234--------------------
        {108729312, 3, 3},
        //{108844696, 4, 1},
        //{108960080, 4, 1},
        //{109075464, 4, 1},
    //235--------------------
        {109190840, 2, 2},
        //{109306224, 4, 1},
        //{109421608, 4, 1},
        {109536992, 2, 2},
    //236--------------------
        //{109652376, 4, 1},
        //{109767760, 4, 1},
        {109883144, 2, 2},
        //{109998520, 4, 1},
    //237--------------------
        {110113904, 3, 3},
        //{110229288, 4, 1},
        //{110344672, 4, 1},
        //{110460056, 4, 1},
    //238--------------------
        {110575440, 1, 1},
        //{110690824, 4, 1},
        //{110806200, 4, 1},
        //{110921584, 4, 1},
    //239--------------------
        {111036968, 3, 3},
        //{111152352, 4, 1},
        //{111267736, 4, 1},
        {111383120, 3, 3},
    //240--------------------
        //{111498496, 4, 1},
        //{111613880, 4, 1},
        {111729264, 3, 3},
        //{111844648, 4, 1},
    //241--------------------サビ後半
        {111960032, 1, 1},
        //{112075416, 4, 1},
        //{112190800, 4, 1},
        //{112306176, 3, 3},
    //242--------------------
        //{112421560, 3, 3},
        //{112536944, 4, 1},
        {112652328, 3, 3},
        {112767712, 3, 3},
    //243--------------------
        //{112883096, 3, 3},
        //{112998480, 4, 1},
        //{113113856, 4, 1},
        //{113229240, 4, 1},
    //244--------------------
        //{113344624, 4, 1},
        //{113460008, 4, 1},
        {113575392, 2, 2},
        {113690776, 2, 2},
    //245--------------------
        //{113806160, 4, 1},
        //{113921536, 4, 1},
        {114036920, 2, 2},
        //{114152304, 4, 1},
    //246--------------------
        //{114267688, 4, 1},
        //{114383072, 4, 1},
        {114498456, 2, 2},
        //{114613832, 4, 1},
    //247--------------------
        //{114729216, 4, 1},
        //{114844600, 4, 1},
        //{114959984, 4, 1},
        {115075368, 3, 3},
    //248--------------------
        //{115190752, 4, 1},
        {115306136, 3, 3},
        //{115421512, 4, 1},
        {115536896, 3, 3},
    //249--------------------
        //{115652280, 4, 1},
        //{115767664, 4, 1},
        //{115883048, 4, 1},
        //{115998432, 4, 1},
    //250--------------------
        //{116113816, 4, 1},
        //{116229192, 4, 1},
        {116344576, 4, 4},
        {116459960, 4, 4},
    //251--------------------
        //{116575344, 4, 1},
        //{116690728, 4, 1},
        //{116806112, 4, 1},
        //{116921496, 4, 1},
    //252--------------------
        //{117036872, 4, 1},
        //{117152256, 4, 1},
        {117267640, 1, 1},
        {117383024, 1, 1},
    //253--------------------
        //{117498408, 4, 1},
        //{117613792, 4, 1},
        {117729168, 1, 1},
        //{117844552, 4, 1},
    //254--------------------
        //{117959936, 4, 1},
        //{118075320, 4, 1},
        {118190704, 1, 1},
        //{118306088, 4, 1},
    //255--------------------
        //{118421472, 4, 1},
        //{118536848, 4, 1},
        //{118652232, 4, 1},
        {118767616, 4, 4},
    //256--------------------
        //{118883000, 4, 1},
        {118998384, 4, 4},
        //{119113768, 4, 1},
        {119229152, 4, 4},
    //257--------------------last
        {119344528, 4, 4},
        //{119459912, 4, 1},
        //{119575296, 4, 1},
        //{119690680, 4, 1},
    //258--------------------
        {119806064, 3, 3},
        //{119921448, 4, 1},
        //{120036832, 4, 1},
        //{120152208, 4, 1},
    //259--------------------
        {120267592, 4, 4},
        //{120382976, 4, 1},
        //{120498360, 4, 1},
        //{120613744, 4, 1},
    //260--------------------
        {120729128, 3, 3},
        //{120844504, 4, 1},
        //{120959888, 4, 1},
        //{121075272, 4, 1},
    //261--------------------
        {121190656, 1, 1},
        //{121306040, 4, 1},
        //{121421424, 4, 1},
        //{121536808, 4, 1},
    //262--------------------
        {121652184, 2, 2},
        //{121767568, 4, 1},
        //{121882952, 4, 1},
        //{121998336, 4, 1},
    //263--------------------
        {122113720, 1, 1},
        //{122229104, 4, 1},
        //{122344488, 4, 1},
        //{122459864, 4, 1},
    //264--------------------
        {122575248, 2, 2},
        //{122690632, 4, 1},
        //{122806016, 4, 1},
        //{122921400, 4, 1},
    //265--------------------
        {123036784, 1, 1},
        //{123152168, 4, 1},
        {123267544, 1, 1},
        //{123382928, 4, 1},
    //266--------------------
        {123498312, 2, 2},
        //{123613696, 4, 1},
        {123729080, 2, 2},
        //{123844464, 4, 1},
    //267--------------------
        {123959840, 4, 4},
        //{124075224, 4, 1},
        {124190608, 4, 4},
        //{124305992, 4, 1},
    //268--------------------
        {124421376, 3, 3},
        //{124536760, 4, 1},
        {124652144, 3, 3},
        //{124767520, 4, 1},
    //269--------------------
        {124882904, 1, 1},
        //{124998288, 4, 1},
        {125113672, 1, 1},
        //{125229056, 4, 1},
    //270--------------------
        {125344440, 1, 1},
        //{125459824, 4, 1},
        {125575200, 1, 1},
        //{125690584, 4, 1},
    //271--------------------
        {125805968, 3, 3},
        {125921352, 3, 3},
        {126036736, 3, 3},
        {126152120, 3, 3},
    //272--------------------
        {126267504, 3, 3},
        {126382880, 3, 3},
        {126498264, 3, 3},
        {126613648, 3, 3},
    //273--------------------
        {126729032, 2, 2},
        //{126844416, 4, 1},
        //{126959800, 4, 1},
        //{127075176, 4, 1},
    //274--------------------
        //{127190560, 4, 1},
        //{127305944, 4, 1},
        //{127421328, 4, 1},
        //{127536712, 4, 1},
    //275--------------------
        //{127652096, 4, 1},
        //{127767480, 4, 1},
        //{127882856, 4, 1},
        //{127998240, 4, 1},
    //276--------------------
        //{128113624, 4, 1},
        //{128229008, 4, 1},
        //{128344392, 4, 1},
        //{128459776, 4, 1},
    };
}