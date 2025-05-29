import axios, { AxiosResponse } from 'axios';
import useSWR from 'swr';
import { FilterGUTPeriodicidade } from "../Filters/GUTPeriodicidade"
import { GUTPeriodicidade } from "../../Models/GUTPeriodicidade";
import { IGUTPeriodicidade } from '../Interfaces/interface.GUTPeriodicidade';
import { decodeBase64Token, fetcher } from '@/app/tools/Fetcher';
import { INotificationService, INotifySystemEntity, NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';

export class GUTPeriodicidadeApi {
    private authorization: string;
    private baseUrl: string;
    private notificationService: INotificationService;

    constructor(uri: string, authorization: string, version: number = parseInt(process.env.NEXT_PUBLIC_URL_VERSION_API ?? '2')) {
        this.authorization = authorization;
        this.baseUrl = `${process.env.NEXT_PUBLIC_URL_API_BASE}${version}/${uri}/GUTPeriodicidade`;
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
            entity: "GUTPeriodicidade",
            id: id,
            action: action
        };
    }

    public async getAll(max: number = 1000): Promise<AxiosResponse> {
        return axios.get(`${this.baseUrl}/GetAll?max=${max}`, this.getHeaders());
    }

    public async getById(id: number): Promise<AxiosResponse> {
        return await axios.get(`${this.baseUrl}/GetById/${id}`, this.getHeaders());
    }

    public async getListN(max?: number, filtro?: FilterGUTPeriodicidade): Promise<AxiosResponse> {
        if (max === undefined) max = 200;
        return axios.post(`${this.baseUrl}/GetListN/?max=${max}`, filtro, this.getHeaders());
    }

    public async filter(filtro: FilterGUTPeriodicidade): Promise<AxiosResponse> {
        return axios.post(`${this.baseUrl}/Filter`, filtro, this.getHeaders());
    }

    public async addAndUpdate(regGUTPeriodicidade: IGUTPeriodicidade): Promise<AxiosResponse> {
        try {
            var result = await axios.post(`${this.baseUrl}/AddAndUpdate`, regGUTPeriodicidade as GUTPeriodicidade, this.getHeaders());
            var register = result.data as IGUTPeriodicidade;        
            const action = regGUTPeriodicidade.id == 0 ? NotifySystemActions.ADD : NotifySystemActions.UPDATE;
            const notificationEntity = this.createNotificationEntity(register.id, action);        
            this.notificationService.notify(notificationEntity);
            return result; } 
        catch (error: any) {
            if (error.response && error.response.status === 409) {
                if (error.response && error.response.data) {
                    const { message } = error.response.data;
                    // Erro de validação, o registro já existe
                    const errorMessage = message || 'Verifique se o registro já existe!';
                    this.notificationService.notify({
                        entity: "GUTPeriodicidade",
                        id: regGUTPeriodicidade.id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });

                }
            }
            throw error;
        }
    }

    public async delete(id: number): Promise<AxiosResponse | void> {
        try {
            const result = await axios.delete(`${this.baseUrl}/Delete?id=${id}`, this.getHeaders());
             if (result.data) {
                if (result.data.success === false) {
                    throw new Error(result.data.message || 'Erro ao excluir.');
                }
                const notificationEntity = this.createNotificationEntity(id, NotifySystemActions.DELETE);
                this.notificationService.notify(notificationEntity);
            }
            return result;
        } catch (error: any) {
            if (error.response && error.response.status === 409) {
              if (error.response && error.response.data) {
                    const { message } = error.response.data;
                    // Conflito, o registro está vinculado a outros registros
                    const errorMessage = message|| 'Erro ao excluir o GUTPeriodicidade. Verifique se ele não está vinculado a outros registros.';
                    this.notificationService.notify({
                        entity: "GUTPeriodicidade",
                        id: id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });
                    throw new Error(error.data.message || 'Erro ao excluir.');
                }
            }
            throw error;                   
        }
    }

    public useFilter(filtro: FilterGUTPeriodicidade) {
        const url = `${this.baseUrl}/Filter`;
        const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
        return useSWR<GUTPeriodicidade[]>(key, fetcher, {
            revalidateOnFocus: false,
            revalidateOnReconnect: false
        });
    }

}
