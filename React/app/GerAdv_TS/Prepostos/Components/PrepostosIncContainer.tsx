'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PrepostosInc from '../Crud/Inc/Prepostos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PrepostosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const PrepostosIncContainer: React.FC<PrepostosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <PrepostosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default PrepostosIncContainer;