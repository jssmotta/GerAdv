import axios, { AxiosResponse } from 'axios';
import useSWR from 'swr';
import { FilterAgendaSemana } from "../Filters/AgendaSemana"
import { AgendaSemana } from "../../Models/AgendaSemana";
import { IAgendaSemana } from '../Interfaces/interface.AgendaSemana';
import { GetColumns, UpdateColumnsRequest } from "../../Models/Columns";
import { decodeBase64Token, fetcher } from '@/app/tools/Fetcher';
import { INotificationService, INotifySystemEntity, NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';

export class AgendaSemanaApi {
    private authorization: string;
    private baseUrl: string;
    private notificationService: INotificationService;

    constructor(uri: string, authorization: string) {
        this.authorization = authorization;
        this.baseUrl = `${process.env.NEXT_PUBLIC_URL_API}/${uri}/AgendaSemana`;
        this.notificationService = new NotificationService();
    }

    private getHeaders() {
        return {
            headers: {
                Authorization: `Bearer ${decodeBase64Token(this.authorization)}`,
                'Content-Type': 'application/json',
            },
        };
    }

    private createNotificationEntity(
        id: number, 
        action: NotifySystemActions = NotifySystemActions.DELETE): INotifySystemEntity {
        return {
            entity: "AgendaSemana",
            id: id,
            action: action
        };
    }

    public async filter(filtro: FilterAgendaSemana): Promise<AxiosResponse> {
        return axios.post(`${this.baseUrl}/Filter`, filtro, this.getHeaders());
    }

    public async addAndUpdate(regAgendaSemana: IAgendaSemana): Promise<AxiosResponse> {
        var result = await axios.post(`${this.baseUrl}/AddAndUpdate`, regAgendaSemana as AgendaSemana, this.getHeaders());
        var register = result.data as IAgendaSemana;        
        const action = regAgendaSemana.id == 0 ? NotifySystemActions.ADD : NotifySystemActions.UPDATE;
        const notificationEntity = this.createNotificationEntity(register.id, action);        
        this.notificationService.notify(notificationEntity);
        return result;
    }

    public async updateColumns(parameters: UpdateColumnsRequest): Promise<AxiosResponse> {
        return axios.post(`${this.baseUrl}/UpdateColumns`, parameters, this.getHeaders());
    }

    public async getColumns(parameters: GetColumns): Promise<AxiosResponse> {
        return axios.post(`${this.baseUrl}/GetColumns`, parameters, this.getHeaders());
    }

    public async delete(id: number): Promise<AxiosResponse> {
        var result = await axios.delete(`${this.baseUrl}/Delete?id=${id}`, this.getHeaders());
        if (result.data) {
            const notificationEntity = this.createNotificationEntity(id, NotifySystemActions.DELETE);        
            this.notificationService.notify(notificationEntity);          
        }
        return result;
    }

    public useFilter(filtro: FilterAgendaSemana) {
        const url = `${this.baseUrl}/Filter`;
        const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
        return useSWR<AgendaSemana[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useGetColumns(parameters: GetColumns) {
        const url = `${this.baseUrl}/GetColumns`;
        const key = `${url}::${this.authorization}`;
        return useSWR<AgendaSemana[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

}
