import axios, { AxiosResponse } from 'axios';
import useSWR from 'swr';
import { FilterStatusAndamento } from "../Filters/StatusAndamento"
import { StatusAndamento } from "../../Models/StatusAndamento";
import { IStatusAndamento } from '../Interfaces/interface.StatusAndamento';
import { GetColumns, UpdateColumnsRequest } from "../../Models/Columns";
import { decodeBase64Token, fetcher } from '@/app/tools/Fetcher';
import { INotificationService, INotifySystemEntity, NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';

export class StatusAndamentoApi {
    private authorization: string;
    private baseUrl: string;
    private notificationService: INotificationService;

    constructor(uri: string, authorization: string) {
        this.authorization = authorization;
        this.baseUrl = `${process.env.NEXT_PUBLIC_URL_API}/${uri}/StatusAndamento`;
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
            entity: "StatusAndamento",
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

    public async getListN(max?: number, filtro?: FilterStatusAndamento): Promise<AxiosResponse> {
        if (max === undefined) max = 200;
        return axios.post(`${this.baseUrl}/GetListN/?max=${max}`, filtro, this.getHeaders());
    }

    public async filter(filtro: FilterStatusAndamento): Promise<AxiosResponse> {
        return axios.post(`${this.baseUrl}/Filter`, filtro, this.getHeaders());
    }

    public async addAndUpdate(regStatusAndamento: IStatusAndamento): Promise<AxiosResponse> {
        var result = await axios.post(`${this.baseUrl}/AddAndUpdate`, regStatusAndamento as StatusAndamento, this.getHeaders());
        var register = result.data as IStatusAndamento;        
        const action = regStatusAndamento.id == 0 ? NotifySystemActions.ADD : NotifySystemActions.UPDATE;
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

    // SWR Hooks
    public useGetAll(max: number = 1000) {
        const url = `${this.baseUrl}/GetAll?max=${max}`;
        const key = `${url}::${this.authorization}`;
        return useSWR<StatusAndamento[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useGetById(id: number) {
        const url = `${this.baseUrl}/GetById/${id}`;
        const key = `${url}::${this.authorization}`;
        return useSWR<StatusAndamento>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useGetByName(name: string) {
        const url = `${this.baseUrl}/GetByName/${name}`;
        const key = `${url}::${this.authorization}`;
        return useSWR<StatusAndamento>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useGetListN(max: number = 200, filtro?: FilterStatusAndamento) {
        const url = `${this.baseUrl}/GetListN/?max=${max}`;
        const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
        return useSWR<StatusAndamento[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useFilter(filtro: FilterStatusAndamento) {
        const url = `${this.baseUrl}/Filter`;
        const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
        return useSWR<StatusAndamento[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

    public useGetColumns(parameters: GetColumns) {
        const url = `${this.baseUrl}/GetColumns`;
        const key = `${url}::${this.authorization}`;
        return useSWR<StatusAndamento[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

}
