'use client';
import axios, { AxiosError, AxiosResponse } from 'axios';
import useSWR from 'swr';
import { FilterAgendaSemana } from '../Filters/AgendaSemana'
import { AgendaSemana } from '../../Models/AgendaSemana';
import { IAgendaSemana } from '../Interfaces/interface.AgendaSemana';
import { decodeBase64Token, fetcher } from '@/app/tools/Fetcher';
import { INotificationService, INotifySystemEntity, NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';
import {CRUD_CONSTANTS} from '@/app/tools/crud';


export class AgendaSemanaApiError extends Error {
  status: number;
  code?: string;
  originalError?: any;

  constructor(message: string, status: number, code?: string, originalError?: any) {
    super(message);
    this.name = 'AgendaSemanaApiError';
    this.status = status;
    this.code = code;
    this.originalError = originalError;
  }

  toString() {
    return `${this.name}: ${this.message} (status: ${this.status})`;
  }
}

export class AgendaSemanaApi {
    private authorization: string;
    private baseUrl: string;
    private notificationService: INotificationService;
    private uri: string;

    constructor(uri: string, authorization: string, version: number = parseInt(process.env.NEXT_PUBLIC_URL_VERSION_API ?? '1')) {
        this.authorization = authorization;
        this.baseUrl = `${process.env.NEXT_PUBLIC_URL_API_BASE}${version}/${uri}/AgendaSemana`;
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
            entity: 'AgendaSemana',
            id: id,
            action: action
        };
    }

    private createNotificationOffLiveEntity(
        id: number,
        action: NotifySystemActions = NotifySystemActions.INFO,
        message?: string): INotifySystemEntity {
        return {
            entity: 'AgendaSemana',
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

            throw new AgendaSemanaApiError(
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

        throw new AgendaSemanaApiError(
            `${context}: Erro desconhecido`,
            500,
            'UNKNOWN_ERROR',
            error
        );
    }



            public async filter(filtro: FilterAgendaSemana): Promise<AxiosResponse> {
                const storageKey = btoa(`${process.env.NEXT_PUBLIC_APP_ID}-${this.uri}-AgendaSemana_last_filter_data_${JSON.stringify(filtro)}`);
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

                    this.handleApiError(error, 'Erro ao filtrar AgendaSemana');
                }
            }


    public async validation(regAgendaSemana: IAgendaSemana): Promise<{ isValid: boolean; message: string } | null> {
        try {
            const result = await axios.post(`${this.baseUrl}/validation`, regAgendaSemana as AgendaSemana, this.getHeaders());
            // Se a resposta for bem-sucedida, retorna true
            return { isValid: true, message: 'Validação bem-sucedida' };
        } catch (error: any) {
            if (error.response && (error.response.status === 409 || error.response.status === 500)) {
                if (error.response && error.response.data) {
                    const { message } = error.response.data;
                    // Erro de validação, o registro já existe
                    const errorMessage = message || 'Verifique se o registro já existe!';
                    return { isValid: false, message: errorMessage };                    
                }
            }
            return { isValid: false, message: 'Erro desconhecido ao validar na base.' };;
        }
    }


    public async addAndUpdate(regAgendaSemana: IAgendaSemana): Promise<AxiosResponse> {
        try {
            var result = await axios.post(`${this.baseUrl}/AddAndUpdate`, regAgendaSemana as AgendaSemana, this.getHeaders());
            var register = result.data as IAgendaSemana;        
            const action = regAgendaSemana.id == 0 ? NotifySystemActions.ADD : NotifySystemActions.UPDATE;
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
                        entity: 'AgendaSemana',
                        id: regAgendaSemana.id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });

                }
            }

            this.handleApiError(error, 'Erro ao salvar Agenda Semana');
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
                    const errorMessage = message|| 'Erro ao excluir o AgendaSemana. Verifique se ele não está vinculado a outros registros.';
                    this.notificationService.notify({
                        entity: 'AgendaSemana',
                        id: id,
                        action: NotifySystemActions.ERROR,
                        message: errorMessage
                    });
                    throw new Error(error.data.message || 'Erro ao excluir.');
                }
            }
             this.handleApiError(error, `Erro ao excluir Agenda Semana com ID ${id}`);                
        }
    }




    public useFilter(filtro: FilterAgendaSemana) {
       const url = `${this.baseUrl}/Filter`;
       const key = `${url}::${this.authorization}::${JSON.stringify(filtro)}`;
    
        return useSWR<AgendaSemana[]>(key, fetcher, {
          revalidateOnFocus: false,
          revalidateOnReconnect: false,
          onError: (error) => {
            console.error('Erro no SWR para filtro de agendasemana:', error);
            this.notificationService.notify({
              entity: 'AgendaSemana',
              id: 0,
              action: NotifySystemActions.ERROR,
              message: 'Erro ao carregar dados dos agendasemana'
            });
          }
        });
    }

}
