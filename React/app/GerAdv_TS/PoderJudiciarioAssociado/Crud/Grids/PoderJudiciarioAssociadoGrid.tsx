//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { PoderJudiciarioAssociadoEmpty } from '../../../Models/PoderJudiciarioAssociado';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IPoderJudiciarioAssociado } from '../../Interfaces/interface.PoderJudiciarioAssociado';
import { PoderJudiciarioAssociadoService } from '../../Services/PoderJudiciarioAssociado.service';
import { PoderJudiciarioAssociadoApi } from '../../Apis/ApiPoderJudiciarioAssociado';
import { PoderJudiciarioAssociadoGridMobileComponent } from '../GridsMobile/PoderJudiciarioAssociado';
import { PoderJudiciarioAssociadoGridDesktopComponent } from '../GridsDesktop/PoderJudiciarioAssociado';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterPoderJudiciarioAssociado } from '../../Filters/PoderJudiciarioAssociado';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import PoderJudiciarioAssociadoWindow from './PoderJudiciarioAssociadoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { usePoderJudiciarioAssociadoList } from '../../Hooks/hookPoderJudiciarioAssociado';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const PoderJudiciarioAssociadoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const poderjudiciarioassociadoService = useMemo(() => {
    return new PoderJudiciarioAssociadoService(
    new PoderJudiciarioAssociadoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: poderjudiciarioassociado, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = usePoderJudiciarioAssociadoList(poderjudiciarioassociadoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedPoderJudiciarioAssociado, setSelectedPoderJudiciarioAssociado] = useState<IPoderJudiciarioAssociado>(PoderJudiciarioAssociadoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterPoderJudiciarioAssociado | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterPoderJudiciarioAssociado | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterPoderJudiciarioAssociado);
};
// Handlers para o grid
const handleRowClick = (poderjudiciarioassociado: IPoderJudiciarioAssociado) => {
  setSelectedPoderJudiciarioAssociado(poderjudiciarioassociado);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedPoderJudiciarioAssociado(PoderJudiciarioAssociadoEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const poderjudiciarioassociado = e.dataItem;
  setDeleteId(poderjudiciarioassociado.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await poderjudiciarioassociadoService.deletePoderJudiciarioAssociado(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <PoderJudiciarioAssociadoGridMobileComponent
    data={poderjudiciarioassociado}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <PoderJudiciarioAssociadoGridDesktopComponent
    data={poderjudiciarioassociado}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <PoderJudiciarioAssociadoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedPoderJudiciarioAssociado={selectedPoderJudiciarioAssociado}
    />

    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default PoderJudiciarioAssociadoGrid;