#ifndef __CONSTS__
#define __CONSTS__

#define MAX_COMMAND_PARAMS  (8)
#define NULL_PTR            (0)
#define UNDEFINED_PARAM_IDX	(255)


//const uint8_t getValueTypeID() = 0;
#define BOOL_VALUE_TYPEID     (0)
#define UINT8_VALUE_TYPEID    (1)
#define UINT16_VALUE_TYPEID   (2)
#define UINT32_VALUE_TYPEID   (3)
#define INT8_VALUE_TYPEID     (4)
#define INT16_VALUE_TYPEID    (5)
#define INT32_VALUE_TYPEID    (6)
#define DOUBLE_VALUE_TYPEID   (7)

#define PARAM_VALUE_LENGTH		(16)
#define CMD_PARAMS_COUNT        (8)

#define INCLUDE_EDPF_DEMO_KIT			(1)

#define INCLUDE_PARAM_IO_COMMAND		(1)
#define INCLUDE_SHOW_HIGHLIGHTS_COMMAND	(1)
#define INCLUDE_CHARTING_VALUES_COMMAND	(1)

/////////////////////////////////////////////
// EDPF_DEMO_KIT CONSTS
//
// The EDPF demo kit is a gamepad controller
// (think XBox or PlayStation) that is based
// on an Arduino Nano uPC. 
//
/////////////////////////////////////////////

// the joysticks Y axis
#define EDPF_DEMO_STICK_PRESS_PIN	(A3)

// the joysticks Y axis
#define EDPF_DEMO_STICK_VRY_PIN		(A4)

// the joysticks X axis
#define EDPF_DEMO_STICK_VRX_PIN		(A5)

#define D6							(6)
#define D5							(5)
#define D4							(4)
#define D3							(3)
#define D2							(2)
#define D1							(1)

#define EDPD_DEMO_BUTTON_B1			(D6)
#define EDPD_DEMO_BUTTON_B2			(D5)
#define EDPD_DEMO_BUTTON_B3			(D4)
#define EDPD_DEMO_BUTTON_B4			(D3)





#endif //__CONSTS__
