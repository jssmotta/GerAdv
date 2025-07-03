'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ModelosDocumentosInc from '../Crud/Inc/ModelosDocumentos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ModelosDocumentosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ModelosDocumentosIncContainer: React.FC<ModelosDocumentosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ModelosDocumentosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ModelosDocumentosIncContainer;