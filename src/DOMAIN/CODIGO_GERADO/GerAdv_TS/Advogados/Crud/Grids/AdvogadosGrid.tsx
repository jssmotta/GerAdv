//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AdvogadosEmpty } from "../../../Models/Advogados";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AdvogadosInc from "../Inc/Advogados";
import { IAdvogados } from "../../Interfaces/interface.Advogados";
import { AdvogadosService } from "../../Services/Advogados.service";
import { AdvogadosApi } from "../../Apis/ApiAdvogados";
import { AdvogadosGridMobileComponent } from "../GridsMobile/Advogados";
import { AdvogadosGridDesktopComponent } from "../GridsDesktop/Advogados";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAdvogados } from "../../Filters/Advogados";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AdvogadosWindow from "./AdvogadosWindow";

const AdvogadosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [advogados, setAdvogados] = useState<IAdvogados[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAdvogados, setSelectedAdvogados] = useState<IAdvogados>(AdvogadosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAdvogados | undefined | null>(null);

    const advogadosService = useMemo(() => {
      return new AdvogadosService(
          new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAdvogados = async (filtro?: FilterAdvogados | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await advogadosService.getList(filtro ?? {} as FilterAdvogados);
        setAdvogados(data);
      }
      else {
        const data = await advogadosService.getAll(filtro ?? {} as FilterAdvogados);
        setAdvogados(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAdvogados(currFilter);
    }, [showInc]);
  
    const handleRowClick = (advogados: IAdvogados) => {
      if (isMobile) {
        router.push(`/pages/advogados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${advogados.id}`);
      } else {
        setSelectedAdvogados(advogados);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/advogados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAdvogados(AdvogadosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAdvogados(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const advogados = e.dataItem;		
        setDeleteId(advogados.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAdvogados(currFilter);
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
           <AdvogadosGridMobileComponent data={advogados} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AdvogadosGridDesktopComponent data={advogados} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AdvogadosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAdvogados={selectedAdvogados}>       
        </AdvogadosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AdvogadosGrid;