//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OponentesEmpty } from '../../../Models/Oponentes';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOponentes } from '../../Interfaces/interface.Oponentes';
import { OponentesService } from '../../Services/Oponentes.service';
import { OponentesApi } from '../../Apis/ApiOponentes';
import { OponentesGridMobileComponent } from '../GridsMobile/Oponentes';
import { OponentesGridDesktopComponent } from '../GridsDesktop/Oponentes';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOponentes } from '../../Filters/Oponentes';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OponentesWindow from './OponentesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOponentesList } from '../../Hooks/hookOponentes';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const OponentesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const oponentesService = useMemo(() => {
    return new OponentesService(
    new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: oponentes, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOponentesList(oponentesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOponentes, setSelectedOponentes] = useState<IOponentes>(OponentesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOponentes | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOponentes | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOponentes);
};
// Handlers para o grid
const handleRowClick = (oponentes: IOponentes) => {
  setSelectedOponentes(oponentes);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOponentes(OponentesEmpty());
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
  const oponentes = e.dataItem;
  setDeleteId(oponentes.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await oponentesService.deleteOponentes(deleteId);
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
    <OponentesGridMobileComponent
    data={oponentes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OponentesGridDesktopComponent
    data={oponentes}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OponentesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOponentes={selectedOponentes}
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
export default OponentesGrid;