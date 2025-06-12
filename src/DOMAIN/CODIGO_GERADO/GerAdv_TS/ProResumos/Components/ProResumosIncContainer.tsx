'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProResumosInc from '../Crud/Inc/ProResumos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProResumosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ProResumosIncContainer: React.FC<ProResumosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ProResumosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ProResumosIncContainer;