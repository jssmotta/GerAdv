//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoModeloDocumentoEmpty } from "../../../Models/TipoModeloDocumento";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ITipoModeloDocumento } from "../../Interfaces/interface.TipoModeloDocumento";
import { TipoModeloDocumentoService } from "../../Services/TipoModeloDocumento.service";
import { TipoModeloDocumentoApi } from "../../Apis/ApiTipoModeloDocumento";
import { TipoModeloDocumentoGridMobileComponent } from "../GridsMobile/TipoModeloDocumento";
import { TipoModeloDocumentoGridDesktopComponent } from "../GridsDesktop/TipoModeloDocumento";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoModeloDocumento } from "../../Filters/TipoModeloDocumento";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import TipoModeloDocumentoWindow from "./TipoModeloDocumentoWindow";

const TipoModeloDocumentoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipomodelodocumento, setTipoModeloDocumento] = useState<ITipoModeloDocumento[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoModeloDocumento, setSelectedTipoModeloDocumento] = useState<ITipoModeloDocumento>(TipoModeloDocumentoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoModeloDocumentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoModeloDocumento | undefined | null>(null);

    const tipomodelodocumentoService = useMemo(() => {
      return new TipoModeloDocumentoService(
          new TipoModeloDocumentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoModeloDocumento = async (filtro?: FilterTipoModeloDocumento | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipomodelodocumentoService.getList(filtro ?? {} as FilterTipoModeloDocumento);
        setTipoModeloDocumento(data);
      }
      else {
        const data = await tipomodelodocumentoService.getAll(filtro ?? {} as FilterTipoModeloDocumento);
        setTipoModeloDocumento(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoModeloDocumento(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipomodelodocumento: ITipoModeloDocumento) => {
      if (isMobile) {
        router.push(`/pages/tipomodelodocumento/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipomodelodocumento.id}`);
      } else {
        setSelectedTipoModeloDocumento(tipomodelodocumento);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipomodelodocumento/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoModeloDocumento(TipoModeloDocumentoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoModeloDocumento(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipomodelodocumento = e.dataItem;		
        setDeleteId(tipomodelodocumento.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoModeloDocumento(currFilter);
            } catch {
            // falta uma mensagem de erro
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

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <TipoModeloDocumentoGridMobileComponent data={tipomodelodocumento} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <TipoModeloDocumentoGridDesktopComponent data={tipomodelodocumento} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <TipoModeloDocumentoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoModeloDocumento={selectedTipoModeloDocumento}>       
        </TipoModeloDocumentoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoModeloDocumentoGrid;