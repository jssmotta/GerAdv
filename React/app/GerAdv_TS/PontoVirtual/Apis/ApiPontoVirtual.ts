'use client';
import axios, { AxiosError, AxiosResponse } from 'axios';
import useSWR from 'swr';
import { FilterPontoVirtual } from '../Filters/PontoVirtual'
import { PontoVirtual } from '../../Models/PontoVirtual';
import { IPontoVirtual } from '../Interfaces/interface.PontoVirtual';
import { decodeBase64Token, fetcher } from '@/app/tools/Fetcher';
import { INotificationService, INotifySystemEntity, NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';
import {CRUD_CONSTANTS} from '@/app/tools/crud';


export class PontoVirtualApiError extends Error {
        constructor(
            message: string,
            public status: number,
            public code?: string,
            public originalError?: any
        ) {
            super(message);
            this.name = 'PontoVirtualApiError';
        }
    }

export class PontoVirtualApi {
    private authorization: string;
    private baseUrl: string;
    private notificationService: INotificationService;
    private uri: string;

    constructor(uri: string, authorization: string, version: number = parseInt(process.env.NEXT_PUBLIC_URL_VERSION_API ?? '2')) {
        this.authorization = authorization;
        this.baseUrl = `${process.env.NEXT_PUBLIC_URL_API_BASE}${version}/${uri}/PontoVirtual`;
        this.notificationService = new NotificationService();
        this.uri = uri;
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
            entity: 'PontoVirtual',
            id: id,
            action: action
        };
    }

    private createNotificationOffLiveEntity(
        id: number,
        action: NotifySystemActions = NotifySystemActions.INFO,
        message?: string): INotifySystemEntity {
        return {
            entity: 'PontoVirtual',
            id: id,
            action: action,
            message: message ?? `Trabalhando off-line.`
        };
    }


    private handleApiError(error: any, context: string): never {
        if (axios.isAxiosError(error)) {
            const axiosError = error as AxiosError;
            const status = axiosError.response?.status || 500;
            const message = (axiosError.response?.data as { message?: string })?.message || axiosError.message;

            this.notificationService.notify(
                this.createNotificationOffLiveEntity(0, NotifySystemActions.ERROR, message ?? 'Erro desconhecido')
            );

            throw new PontoVirtualApiError(
                `${context}: ${message}`,
                status,
                axiosError.code,
                error
            );
        }
        else {
            this.notificationService.notify(
                this.createNotificationOffLiveEntity(0, NotifySystemActions.ERROR, 'Erro desconhecido')
            );
        }

        throw new PontoVirtualApiError(
            `${context}: Erro desconhecido`,
            500,
            'UNKNOWN_ERROR',
            error
        );
    }


   
        public async getAll(max: number = CRUD_CONSTANTS.DEFAULT_MAX_RECORDS): Promise<AxiosResponse> {
        const storageKey = btoa(`${process.env.NEXT_PUBLIC_APP_ID}-${this.uri}-PontoVirtual_last_getAll_${max}`);
        try {
            const response = await axios.get(`${this.baseUrl}/GetAll?max=${max}`, this.getHeaders());
            const encoded = btoa(JSON.stringify(response.data));
            localStorage.setItem(storageKey, encoded);
            return response;
        } catch (error: any) {
            const offlineData = localStorage.getItem(storageKey);
            if (offlineData) {
                const decoded = JSON.parse(atob(offlineData));
                this.notificationService.notify(
                    this.createNotificationOffLiveEntity(0, NotifySystemActions.INFO)
                );
                return {
                    data: decoded,
                    status: 200,
                    statusText: 'OK (offline)',
                    headers: {},
                    config: {},
                } as AxiosResponse;
            }
            this.handleApiError(error, 'Erro ao buscar todos os PontoVirtual');
        }
    }
    
        public async getById(id: number): Promise<AxiosResponse> {
        const storageKey = btoa(`${process.env.NEXT_PUBLIC_APP_ID}-${this.uri}-PontoVirtual_last_getById_${id}`);
        try {
            const response = await axios.get(`${this.baseUrl}/GetById/${id}`, this.getHeaders());
            const encoded = btoa(JSON.stringify(response.data));
            localStorage.setItem(storageKey, encoded);
            return response;
        } catch (error: any) {
            const offlineData = localStorage.getItem(storageKey);
            if (offlineData) {
                const decoded = JSON.parse(atob(offlineData));
                this.notificationService.notify(
                    this.createNotificationOffLiveEntity(id, NotifySystemActions.INFO)
                );
                return {
                    data: decoded,
                    status: 200,
                    statusText: 'OK (offline)',
                    headers: {},
                    config: {},
                } as AxiosResponse;
            }
            this.handleApiError(error, `Erro ao buscar Ponto Virtual com ID ${id}`);
        }
    }

            public async filter(filtro: FilterPontoVirtual): Promise<AxiosResponse> {
                const storageKey = btoa(`${process.env.NEXT_PUBLIC_APP_ID}-${this.uri}-PontoVirtual_last_filter_data_${JSON.stringify(filtro)}`);
                try {
                    const response = await axios.post(`${this.baseUrl}/Filter`, filtro, this.getHeaders());
                    const encoded = btoa(JSON.stringify(response.data));
                    localStorage.setItem(storageKey, encoded);
                    return response;
                } catch (error: any) {
                    const offlineData = localStorage.getItem(storageKey);
                    if (offlineData) {
                        const decoded = JSON.parse(atob(offlineData));
                        this.notificationService.notify(
                            this.createNotificationOffLiveEntity(0, NotifySystemActions.INFO)
                        );
                        return {
                            data: decoded,
                            status: 200,
                            statusText: 'OK (offline)',
                            headers: {},
                            config: {},
                        } as AxiosResponse;
                    }

                    this.handleApiError(error, 'Erro ao filtrar PontoVirtual');
                }
            }


    public async addAndUpdate(regPontoVirtual: IPontoVirtual): Promise<AxiosResponse> {
        try {
            var result = await axios.post(`${this.baseUrl}/AddAndUpdate`, regPontoVirtual as PontoVirtual, this.getHeaders());
            var register = result.data as IPontoVirtual;        
            const action = regPontoVirtual.id == 0 ? NotifySystemActions.ADD : NotifySystemActions.UPDATE;
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
                        entity: 'PontoVirtual',
                        id: regPontoVirtual.id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });

                }
            }

            this.handleApiError(error, 'Erro ao salvar Ponto Virtual');
        }
    }

    public async delete(id: number): Promise<AxiosResponse | void> {
        try {
            const result = await axios.delete(`${this.baseUrl}/Delete?id=${id}`, this.getHeaders());
             if (result.data) {
                /* if (result.data.success === false) {
                    throw new Error(result.data.message || 'Erro ao excluir.');
                } */
                const notificationEntity = this.createNotificationEntity(id, NotifySystemActions.DELETE);
                this.notificationService.notify(notificationEntity);
            }
            return result;
        } catch (error: any) {
            if (error.response && error.response.status === 409) {
              if (error.response && error.response.data) {
                    const { message } = error.response.data;
                    // Conflito, o registro está vinculado a outros registros
                    const errorMessage = message|| 'Erro ao excluir o PontoVirtual. Verifique se ele não está vinculado a outros registros.';
                    this.notificationService.notify({
                        entity: 'PontoVirtual',
                        id: id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });
                    throw new Error(error.data.message || 'Erro ao excluir.');
                }
            }
             this.handleApiError(error, `Erro ao excluir Ponto Virtual com ID ${id}`);                
        }
    }




    public useFilter(filtro: FilterPontoVirtual) {
       const url = `${this.baseUrl}/Filter`;
       const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
    
        return useSWR<PontoVirtual[]>(key, fetcher, {
          revalidateOnFocus: false,
          revalidateOnReconnect: false,
          onError: (error) => {
            console.error('Erro no SWR para filtro de pontovirtual:', error);
            this.notificationService.notify({
              entity: 'PontoVirtual',
              id: 0,
              action: NotifySystemActions.ERROR,
              message: 'Erro ao carregar dados dos pontovirtual'
            });
          }
        });
    }

}
