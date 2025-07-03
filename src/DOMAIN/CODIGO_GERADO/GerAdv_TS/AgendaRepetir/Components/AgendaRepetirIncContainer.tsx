'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaRepetirInc from '../Crud/Inc/AgendaRepetir';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaRepetirIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AgendaRepetirIncContainer: React.FC<AgendaRepetirIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AgendaRepetirInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AgendaRepetirIncContainer;