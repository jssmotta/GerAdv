'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaSemanaInc from '../Crud/Inc/AgendaSemana';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaSemanaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AgendaSemanaIncContainer: React.FC<AgendaSemanaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AgendaSemanaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AgendaSemanaIncContainer;