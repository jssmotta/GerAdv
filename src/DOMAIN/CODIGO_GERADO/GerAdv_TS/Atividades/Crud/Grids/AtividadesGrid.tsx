//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AtividadesEmpty } from "../../../Models/Atividades";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AtividadesInc from "../Inc/Atividades";
import { IAtividades } from "../../Interfaces/interface.Atividades";
import { AtividadesService } from "../../Services/Atividades.service";
import { AtividadesApi } from "../../Apis/ApiAtividades";
import { AtividadesGridMobileComponent } from "../GridsMobile/Atividades";
import { AtividadesGridDesktopComponent } from "../GridsDesktop/Atividades";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAtividades } from "../../Filters/Atividades";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AtividadesWindow from "./AtividadesWindow";

const AtividadesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [atividades, setAtividades] = useState<IAtividades[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAtividades, setSelectedAtividades] = useState<IAtividades>(AtividadesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAtividades | undefined | null>(null);

    const atividadesService = useMemo(() => {
      return new AtividadesService(
          new AtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAtividades = async (filtro?: FilterAtividades | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await atividadesService.getList(filtro ?? {} as FilterAtividades);
        setAtividades(data);
      }
      else {
        const data = await atividadesService.getAll(filtro ?? {} as FilterAtividades);
        setAtividades(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAtividades(currFilter);
    }, [showInc]);
  
    const handleRowClick = (atividades: IAtividades) => {
      if (isMobile) {
        router.push(`/pages/atividades/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${atividades.id}`);
      } else {
        setSelectedAtividades(atividades);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/atividades/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAtividades(AtividadesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAtividades(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const atividades = e.dataItem;		
        setDeleteId(atividades.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAtividades(currFilter);
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
           <AtividadesGridMobileComponent data={atividades} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AtividadesGridDesktopComponent data={atividades} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AtividadesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAtividades={selectedAtividades}>       
        </AtividadesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AtividadesGrid;