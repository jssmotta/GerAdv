'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaQuemInc from '../Crud/Inc/AgendaQuem';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaQuemIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AgendaQuemIncContainer: React.FC<AgendaQuemIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AgendaQuemInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AgendaQuemIncContainer;