import { NomeID } from './NomeID';

export interface DadosSelectProps {
  tabIndex?: number;  
  name: string;
  value: NomeID | number | any | null | undefined;
  setValue?: any;
  label: string;
  type?: string;
  id?: string;
  dataForm?: any;
  className?: string;
  placeholder?: string;
  required?: boolean;
  onChange?: (event: any) => void;
  loading?: boolean;
  maxLength?: number;
  disabled?: boolean;
}
