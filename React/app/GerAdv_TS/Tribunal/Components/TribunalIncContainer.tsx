'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TribunalInc from '../Crud/Inc/Tribunal';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TribunalIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TribunalIncContainer: React.FC<TribunalIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TribunalInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TribunalIncContainer;