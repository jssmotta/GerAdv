//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ModelosDocumentosEmpty } from "../../../Models/ModelosDocumentos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ModelosDocumentosInc from "../Inc/ModelosDocumentos";
import { IModelosDocumentos } from "../../Interfaces/interface.ModelosDocumentos";
import { ModelosDocumentosService } from "../../Services/ModelosDocumentos.service";
import { ModelosDocumentosApi } from "../../Apis/ApiModelosDocumentos";
import { ModelosDocumentosGridMobileComponent } from "../GridsMobile/ModelosDocumentos";
import { ModelosDocumentosGridDesktopComponent } from "../GridsDesktop/ModelosDocumentos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterModelosDocumentos } from "../../Filters/ModelosDocumentos";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ModelosDocumentosWindow from "./ModelosDocumentosWindow";

const ModelosDocumentosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [modelosdocumentos, setModelosDocumentos] = useState<IModelosDocumentos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedModelosDocumentos, setSelectedModelosDocumentos] = useState<IModelosDocumentos>(ModelosDocumentosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ModelosDocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterModelosDocumentos | undefined | null>(null);

    const modelosdocumentosService = useMemo(() => {
      return new ModelosDocumentosService(
          new ModelosDocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchModelosDocumentos = async (filtro?: FilterModelosDocumentos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await modelosdocumentosService.getList(filtro ?? {} as FilterModelosDocumentos);
        setModelosDocumentos(data);
      }
      else {
        const data = await modelosdocumentosService.getAll(filtro ?? {} as FilterModelosDocumentos);
        setModelosDocumentos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchModelosDocumentos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (modelosdocumentos: IModelosDocumentos) => {
      if (isMobile) {
        router.push(`/pages/modelosdocumentos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${modelosdocumentos.id}`);
      } else {
        setSelectedModelosDocumentos(modelosdocumentos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/modelosdocumentos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedModelosDocumentos(ModelosDocumentosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchModelosDocumentos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const modelosdocumentos = e.dataItem;		
        setDeleteId(modelosdocumentos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchModelosDocumentos(currFilter);
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
           <ModelosDocumentosGridMobileComponent data={modelosdocumentos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ModelosDocumentosGridDesktopComponent data={modelosdocumentos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ModelosDocumentosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedModelosDocumentos={selectedModelosDocumentos}>       
        </ModelosDocumentosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ModelosDocumentosGrid;