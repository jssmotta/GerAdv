'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaStatusInc from '../Crud/Inc/AgendaStatus';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaStatusIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AgendaStatusIncContainer: React.FC<AgendaStatusIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AgendaStatusInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AgendaStatusIncContainer;