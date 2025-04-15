import { IContatoCRMView } from "../ContatoCRMView/Interfaces/interface.ContatoCRMView";
export interface ContatoCRMView
{
    id: number;
	data : string;
	ip : string;
}

export function ContatoCRMViewEmpty(): IContatoCRMView {
// 20250125
    return {
        id: 0,
		data: '',
		ip: '',
    };
}
