'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaInc from '../Crud/Inc/Agenda';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AgendaIncContainer: React.FC<AgendaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AgendaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AgendaIncContainer;