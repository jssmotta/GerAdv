'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ModelosDocumentosInc from '../Crud/Inc/ModelosDocumentos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ModelosDocumentosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ModelosDocumentosIncContainer: React.FC<ModelosDocumentosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ModelosDocumentosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ModelosDocumentosIncContainer;