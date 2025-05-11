import axios, { AxiosResponse } from 'axios';
import useSWR from 'swr';
import { FilterNECompromissos } from "../Filters/NECompromissos"
import { NECompromissos } from "../../Models/NECompromissos";
import { INECompromissos } from '../Interfaces/interface.NECompromissos';
import { decodeBase64Token, fetcher } from '@/app/tools/Fetcher';
import { INotificationService, INotifySystemEntity, NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';

export class NECompromissosApi {
    private authorization: string;
    private baseUrl: string;
    private notificationService: INotificationService;

    constructor(uri: string, authorization: string) {
        this.authorization = authorization;
        this.baseUrl = `${process.env.NEXT_PUBLIC_URL_API}/${uri}/NECompromissos`;
        this.notificationService = new NotificationService();
    }

    private getHeaders() {
        return {
            headers: {
                Authorization: `Bearer ${decodeBase64Token(this.authorization)}`,
                'Content-Type': 'application/json',
                'Cache-Control': 'no-cache',     
            },
        };
    }

    private createNotificationEntity(
        id: number, 
        action: NotifySystemActions = NotifySystemActions.DELETE): INotifySystemEntity {
        return {
            entity: "NECompromissos",
            id: id,
            action: action
        };
    }

    public async getAll(max: number = 1000): Promise<AxiosResponse> {
        return axios.get(`${this.baseUrl}/GetAll?max=${max}`, this.getHeaders());
    }

    public async getById(id: number): Promise<AxiosResponse> {
        return axios.get(`${this.baseUrl}/GetById/${id}`, this.getHeaders());
    }

    public async filter(filtro: FilterNECompromissos): Promise<AxiosResponse> {
        return axios.post(`${this.baseUrl}/Filter`, filtro, this.getHeaders());
    }

    public async addAndUpdate(regNECompromissos: INECompromissos): Promise<AxiosResponse> {
        var result = await axios.post(`${this.baseUrl}/AddAndUpdate`, regNECompromissos as NECompromissos, this.getHeaders());
        var register = result.data as INECompromissos;        
        const action = regNECompromissos.id == 0 ? NotifySystemActions.ADD : NotifySystemActions.UPDATE;
        const notificationEntity = this.createNotificationEntity(register.id, action);        
        this.notificationService.notify(notificationEntity);
        return result;
    }

    public async delete(id: number): Promise<AxiosResponse> {
        var result = await axios.delete(`${this.baseUrl}/Delete?id=${id}`, this.getHeaders());
        if (result.data) {
            const notificationEntity = this.createNotificationEntity(id, NotifySystemActions.DELETE);        
            this.notificationService.notify(notificationEntity);          
        }
        return result;
    }

    // SWR Hooks
    public useGetAll(max: number = 1000) {
        const url = `${this.baseUrl}/GetAll?max=${max}`;
        const key = `${url}::${this.authorization}`;
        return useSWR<NECompromissos[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useGetById(id: number) {
        const url = `${this.baseUrl}/GetById/${id}`;
        const key = `${url}::${this.authorization}`;
        return useSWR<NECompromissos>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useFilter(filtro: FilterNECompromissos) {
        const url = `${this.baseUrl}/Filter`;
        const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
        return useSWR<NECompromissos[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

}
