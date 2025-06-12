'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTTipoInc from '../Crud/Inc/GUTTipo';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTTipoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const GUTTipoIncContainer: React.FC<GUTTipoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <GUTTipoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default GUTTipoIncContainer;