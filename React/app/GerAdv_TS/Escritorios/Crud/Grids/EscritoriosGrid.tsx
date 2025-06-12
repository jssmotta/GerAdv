//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { EscritoriosEmpty } from '../../../Models/Escritorios';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IEscritorios } from '../../Interfaces/interface.Escritorios';
import { EscritoriosService } from '../../Services/Escritorios.service';
import { EscritoriosApi } from '../../Apis/ApiEscritorios';
import { EscritoriosGridMobileComponent } from '../GridsMobile/Escritorios';
import { EscritoriosGridDesktopComponent } from '../GridsDesktop/Escritorios';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterEscritorios } from '../../Filters/Escritorios';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import EscritoriosWindow from './EscritoriosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useEscritoriosList } from '../../Hooks/hookEscritorios';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const EscritoriosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const escritoriosService = useMemo(() => {
    return new EscritoriosService(
    new EscritoriosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: escritorios, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useEscritoriosList(escritoriosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedEscritorios, setSelectedEscritorios] = useState<IEscritorios>(EscritoriosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterEscritorios | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterEscritorios | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterEscritorios);
};
// Handlers para o grid
const handleRowClick = (escritorios: IEscritorios) => {
  setSelectedEscritorios(escritorios);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedEscritorios(EscritoriosEmpty());
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
  const escritorios = e.dataItem;
  setDeleteId(escritorios.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await escritoriosService.deleteEscritorios(deleteId);
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
    <EscritoriosGridMobileComponent
    data={escritorios}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <EscritoriosGridDesktopComponent
    data={escritorios}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <EscritoriosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedEscritorios={selectedEscritorios}
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
export default EscritoriosGrid;