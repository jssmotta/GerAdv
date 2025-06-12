import { IAlarmSMS } from '../AlarmSMS/Interfaces/interface.AlarmSMS';
export interface AlarmSMS
{
    id: number;
	operador : number;
	agenda : number;
	recado : number;
	descricao : string;
	hora : number;
	minuto : number;
	d1 : boolean;
	d2 : boolean;
	d3 : boolean;
	d4 : boolean;
	d5 : boolean;
	d6 : boolean;
	d7 : boolean;
	email : string;
	desativar : boolean;
	today : string;
	excetodiasfelizes : boolean;
	desktop : boolean;
	alertardatahora : string;
	guidexo : string;
	emocao : number;
	nomeoperador?: string;

}


export function AlarmSMSEmpty(): IAlarmSMS {
// 20250604
    
    return {
        id: 0,
		operador: 0,
		agenda: 0,
		recado: 0,
		descricao: '',
		hora: 0,
		minuto: 0,
		d1: false,
		d2: false,
		d3: false,
		d4: false,
		d5: false,
		d6: false,
		d7: false,
		email: '',
		desativar: false,
		today: '',
		excetodiasfelizes: false,
		desktop: false,
		alertardatahora: '',
		guidexo: '',
		emocao: 0,
    };
}

export function AlarmSMSTestEmpty(): IAlarmSMS {
// 20250604
    
    return {
        id: 1,
		operador: 1,
		agenda: 1,
		recado: 1,
		descricao: 'X',
		hora: 1,
		minuto: 1,
		d1: true,
		d2: true,
		d3: true,
		d4: true,
		d5: true,
		d6: true,
		d7: true,
		email: 'X',
		desativar: true,
		today: 'X',
		excetodiasfelizes: true,
		desktop: true,
		alertardatahora: 'X',
		guidexo: 'X',
		emocao: 1,
    };
}


