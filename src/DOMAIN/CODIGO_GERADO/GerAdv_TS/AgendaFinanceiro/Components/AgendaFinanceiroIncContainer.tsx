'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaFinanceiroInc from '../Crud/Inc/AgendaFinanceiro';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaFinanceiroIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AgendaFinanceiroIncContainer: React.FC<AgendaFinanceiroIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AgendaFinanceiroInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AgendaFinanceiroIncContainer;