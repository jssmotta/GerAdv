export interface ResultApi<T> {
  data: T;
  success: boolean;
  statusCode: number;
  message: string;
}