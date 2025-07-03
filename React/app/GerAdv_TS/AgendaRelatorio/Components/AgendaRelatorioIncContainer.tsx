'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaRelatorioInc from '../Crud/Inc/AgendaRelatorio';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaRelatorioIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AgendaRelatorioIncContainer: React.FC<AgendaRelatorioIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AgendaRelatorioInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AgendaRelatorioIncContainer;