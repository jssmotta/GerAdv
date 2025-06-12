'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProCDAInc from '../Crud/Inc/ProCDA';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProCDAIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ProCDAIncContainer: React.FC<ProCDAIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ProCDAInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ProCDAIncContainer;