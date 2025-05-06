//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProProcuradoresEmpty } from "../../../Models/ProProcuradores";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IProProcuradores } from "../../Interfaces/interface.ProProcuradores";
import { ProProcuradoresService } from "../../Services/ProProcuradores.service";
import { ProProcuradoresApi } from "../../Apis/ApiProProcuradores";
import { ProProcuradoresGridMobileComponent } from "../GridsMobile/ProProcuradores";
import { ProProcuradoresGridDesktopComponent } from "../GridsDesktop/ProProcuradores";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProProcuradores } from "../../Filters/ProProcuradores";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ProProcuradoresWindow from "./ProProcuradoresWindow";

const ProProcuradoresGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [proprocuradores, setProProcuradores] = useState<IProProcuradores[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProProcuradores, setSelectedProProcuradores] = useState<IProProcuradores>(ProProcuradoresEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProProcuradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProProcuradores | undefined | null>(null);

    const proprocuradoresService = useMemo(() => {
      return new ProProcuradoresService(
          new ProProcuradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProProcuradores = async (filtro?: FilterProProcuradores | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await proprocuradoresService.getList(filtro ?? {} as FilterProProcuradores);
        setProProcuradores(data);
      }
      else {
        const data = await proprocuradoresService.getAll(filtro ?? {} as FilterProProcuradores);
        setProProcuradores(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProProcuradores(currFilter);
    }, [showInc]);
  
    const handleRowClick = (proprocuradores: IProProcuradores) => {
      if (isMobile) {
        router.push(`/pages/proprocuradores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${proprocuradores.id}`);
      } else {
        setSelectedProProcuradores(proprocuradores);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/proprocuradores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProProcuradores(ProProcuradoresEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProProcuradores(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const proprocuradores = e.dataItem;		
        setDeleteId(proprocuradores.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProProcuradores(currFilter);
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
           <ProProcuradoresGridMobileComponent data={proprocuradores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ProProcuradoresGridDesktopComponent data={proprocuradores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ProProcuradoresWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProProcuradores={selectedProProcuradores}>       
        </ProProcuradoresWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProProcuradoresGrid;