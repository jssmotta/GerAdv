//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ParteClienteOutrasEmpty } from '../../../Models/ParteClienteOutras';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IParteClienteOutras } from '../../Interfaces/interface.ParteClienteOutras';
import { ParteClienteOutrasService } from '../../Services/ParteClienteOutras.service';
import { ParteClienteOutrasApi } from '../../Apis/ApiParteClienteOutras';
import { ParteClienteOutrasGridMobileComponent } from '../GridsMobile/ParteClienteOutras';
import { ParteClienteOutrasGridDesktopComponent } from '../GridsDesktop/ParteClienteOutras';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterParteClienteOutras } from '../../Filters/ParteClienteOutras';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ParteClienteOutrasWindow from './ParteClienteOutrasWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useParteClienteOutrasList } from '../../Hooks/hookParteClienteOutras';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ParteClienteOutrasGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const parteclienteoutrasService = useMemo(() => {
    return new ParteClienteOutrasService(
    new ParteClienteOutrasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: parteclienteoutras, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useParteClienteOutrasList(parteclienteoutrasService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedParteClienteOutras, setSelectedParteClienteOutras] = useState<IParteClienteOutras>(ParteClienteOutrasEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterParteClienteOutras | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterParteClienteOutras | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterParteClienteOutras);
};
// Handlers para o grid
const handleRowClick = (parteclienteoutras: IParteClienteOutras) => {
  setSelectedParteClienteOutras(parteclienteoutras);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedParteClienteOutras(ParteClienteOutrasEmpty());
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
  const parteclienteoutras = e.dataItem;
  setDeleteId(parteclienteoutras.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await parteclienteoutrasService.deleteParteClienteOutras(deleteId);
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
    <ParteClienteOutrasGridMobileComponent
    data={parteclienteoutras}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ParteClienteOutrasGridDesktopComponent
    data={parteclienteoutras}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ParteClienteOutrasWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedParteClienteOutras={selectedParteClienteOutras}
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
export default ParteClienteOutrasGrid;