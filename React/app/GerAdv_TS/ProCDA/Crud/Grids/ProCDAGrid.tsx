//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProCDAEmpty } from '../../../Models/ProCDA';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProCDA } from '../../Interfaces/interface.ProCDA';
import { ProCDAService } from '../../Services/ProCDA.service';
import { ProCDAApi } from '../../Apis/ApiProCDA';
import { ProCDAGridMobileComponent } from '../GridsMobile/ProCDA';
import { ProCDAGridDesktopComponent } from '../GridsDesktop/ProCDA';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProCDA } from '../../Filters/ProCDA';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProCDAWindow from './ProCDAWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProCDAList } from '../../Hooks/hookProCDA';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProCDAGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const procdaService = useMemo(() => {
    return new ProCDAService(
    new ProCDAApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: procda, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProCDAList(procdaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProCDA, setSelectedProCDA] = useState<IProCDA>(ProCDAEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProCDA | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProCDA | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProCDA);
};
// Handlers para o grid
const handleRowClick = (procda: IProCDA) => {
  setSelectedProCDA(procda);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProCDA(ProCDAEmpty());
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
  const procda = e.dataItem;
  setDeleteId(procda.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await procdaService.deleteProCDA(deleteId);
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
    <ProCDAGridMobileComponent
    data={procda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProCDAGridDesktopComponent
    data={procda}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProCDAWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProCDA={selectedProCDA}
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
export default ProCDAGrid;