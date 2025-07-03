'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaRepetirDiasInc from '../Crud/Inc/AgendaRepetirDias';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaRepetirDiasIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AgendaRepetirDiasIncContainer: React.FC<AgendaRepetirDiasIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AgendaRepetirDiasInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AgendaRepetirDiasIncContainer;