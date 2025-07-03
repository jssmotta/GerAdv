'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoEMailInc from '../Crud/Inc/TipoEMail';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoEMailIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoEMailIncContainer: React.FC<TipoEMailIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoEMailInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoEMailIncContainer;