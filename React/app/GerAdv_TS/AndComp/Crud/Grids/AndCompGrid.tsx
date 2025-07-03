//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AndCompEmpty } from '../../../Models/AndComp';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAndComp } from '../../Interfaces/interface.AndComp';
import { AndCompService } from '../../Services/AndComp.service';
import { AndCompApi } from '../../Apis/ApiAndComp';
import { AndCompGridMobileComponent } from '../GridsMobile/AndComp';
import { AndCompGridDesktopComponent } from '../GridsDesktop/AndComp';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAndComp } from '../../Filters/AndComp';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AndCompWindow from './AndCompWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAndCompList } from '../../Hooks/hookAndComp';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AndCompGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const andcompService = useMemo(() => {
    return new AndCompService(
    new AndCompApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: andcomp, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAndCompList(andcompService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAndComp, setSelectedAndComp] = useState<IAndComp>(AndCompEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAndComp | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAndComp | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAndComp);
};
// Handlers para o grid
const handleRowClick = (andcomp: IAndComp) => {
  setSelectedAndComp(andcomp);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAndComp(AndCompEmpty());
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
  const andcomp = e.dataItem;
  setDeleteId(andcomp.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await andcompService.deleteAndComp(deleteId);
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
    <AndCompGridMobileComponent
    data={andcomp}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AndCompGridDesktopComponent
    data={andcomp}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AndCompWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAndComp={selectedAndComp}
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
export default AndCompGrid;