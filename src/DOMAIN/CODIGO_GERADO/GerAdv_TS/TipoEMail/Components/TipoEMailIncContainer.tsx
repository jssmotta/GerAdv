'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoEMailInc from '../Crud/Inc/TipoEMail';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoEMailIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TipoEMailIncContainer: React.FC<TipoEMailIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TipoEMailInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TipoEMailIncContainer;