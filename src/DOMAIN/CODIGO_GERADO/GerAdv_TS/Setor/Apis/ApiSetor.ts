import axios, { AxiosResponse } from 'axios';
import useSWR from 'swr';
import { FilterSetor } from "../Filters/Setor"
import { Setor } from "../../Models/Setor";
import { ISetor } from '../Interfaces/interface.Setor';
import { decodeBase64Token, fetcher } from '@/app/tools/Fetcher';
import { INotificationService, INotifySystemEntity, NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';

export class SetorApi {
    private authorization: string;
    private baseUrl: string;
    private notificationService: INotificationService;

    constructor(uri: string, authorization: string) {
        this.authorization = authorization;
        this.baseUrl = `${process.env.NEXT_PUBLIC_URL_API}/${uri}/Setor`;
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
            entity: "Setor",
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

    public async getByName(name: string): Promise<AxiosResponse> {
        return axios.get(`${this.baseUrl}/GetByName/${name}`, this.getHeaders());
    }

    public async getListN(max?: number, filtro?: FilterSetor): Promise<AxiosResponse> {
        if (max === undefined) max = 200;
        return axios.post(`${this.baseUrl}/GetListN/?max=${max}`, filtro, this.getHeaders());
    }

    public async filter(filtro: FilterSetor): Promise<AxiosResponse> {
        return axios.post(`${this.baseUrl}/Filter`, filtro, this.getHeaders());
    }

    public async addAndUpdate(regSetor: ISetor): Promise<AxiosResponse> {
        var result = await axios.post(`${this.baseUrl}/AddAndUpdate`, regSetor as Setor, this.getHeaders());
        var register = result.data as ISetor;        
        const action = regSetor.id == 0 ? NotifySystemActions.ADD : NotifySystemActions.UPDATE;
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
        return useSWR<Setor[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useGetById(id: number) {
        const url = `${this.baseUrl}/GetById/${id}`;
        const key = `${url}::${this.authorization}`;
        return useSWR<Setor>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useGetByName(name: string) {
        const url = `${this.baseUrl}/GetByName/${name}`;
        const key = `${url}::${this.authorization}`;
        return useSWR<Setor>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useGetListN(max: number = 200, filtro?: FilterSetor) {
        const url = `${this.baseUrl}/GetListN/?max=${max}`;
        const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
        return useSWR<Setor[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useFilter(filtro: FilterSetor) {
        const url = `${this.baseUrl}/Filter`;
        const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
        return useSWR<Setor[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

}
