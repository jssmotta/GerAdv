'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import Apenso2Inc from '../Crud/Inc/Apenso2';
import { getParamFromUrl } from '@/app/tools/helpers';
interface Apenso2IncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const Apenso2IncContainer: React.FC<Apenso2IncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <Apenso2Inc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default Apenso2IncContainer;