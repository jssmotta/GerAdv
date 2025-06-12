//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OponentesRepLegalEmpty } from '../../../Models/OponentesRepLegal';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOponentesRepLegal } from '../../Interfaces/interface.OponentesRepLegal';
import { OponentesRepLegalService } from '../../Services/OponentesRepLegal.service';
import { OponentesRepLegalApi } from '../../Apis/ApiOponentesRepLegal';
import { OponentesRepLegalGridMobileComponent } from '../GridsMobile/OponentesRepLegal';
import { OponentesRepLegalGridDesktopComponent } from '../GridsDesktop/OponentesRepLegal';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOponentesRepLegal } from '../../Filters/OponentesRepLegal';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OponentesRepLegalWindow from './OponentesRepLegalWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOponentesRepLegalList } from '../../Hooks/hookOponentesRepLegal';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const OponentesRepLegalGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const oponentesreplegalService = useMemo(() => {
    return new OponentesRepLegalService(
    new OponentesRepLegalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: oponentesreplegal, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOponentesRepLegalList(oponentesreplegalService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOponentesRepLegal, setSelectedOponentesRepLegal] = useState<IOponentesRepLegal>(OponentesRepLegalEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOponentesRepLegal | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOponentesRepLegal | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOponentesRepLegal);
};
// Handlers para o grid
const handleRowClick = (oponentesreplegal: IOponentesRepLegal) => {
  setSelectedOponentesRepLegal(oponentesreplegal);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOponentesRepLegal(OponentesRepLegalEmpty());
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
  const oponentesreplegal = e.dataItem;
  setDeleteId(oponentesreplegal.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await oponentesreplegalService.deleteOponentesRepLegal(deleteId);
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
    <OponentesRepLegalGridMobileComponent
    data={oponentesreplegal}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OponentesRepLegalGridDesktopComponent
    data={oponentesreplegal}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OponentesRepLegalWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOponentesRepLegal={selectedOponentesRepLegal}
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
export default OponentesRepLegalGrid;