'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProResumosInc from '../Crud/Inc/ProResumos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProResumosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProResumosIncContainer: React.FC<ProResumosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProResumosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProResumosIncContainer;