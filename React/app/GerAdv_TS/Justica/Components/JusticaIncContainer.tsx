'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import JusticaInc from '../Crud/Inc/Justica';
import { getParamFromUrl } from '@/app/tools/helpers';
interface JusticaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const JusticaIncContainer: React.FC<JusticaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <JusticaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default JusticaIncContainer;