//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { SetorEmpty } from "../../../Models/Setor";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import SetorInc from "../Inc/Setor";
import { ISetor } from "../../Interfaces/interface.Setor";
import { SetorService } from "../../Services/Setor.service";
import { SetorApi } from "../../Apis/ApiSetor";
import { SetorGridMobileComponent } from "../GridsMobile/Setor";
import { SetorGridDesktopComponent } from "../GridsDesktop/Setor";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterSetor } from "../../Filters/Setor";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import SetorWindow from "./SetorWindow";

const SetorGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [setor, setSetor] = useState<ISetor[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedSetor, setSelectedSetor] = useState<ISetor>(SetorEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new SetorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterSetor | undefined | null>(null);

    const setorService = useMemo(() => {
      return new SetorService(
          new SetorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchSetor = async (filtro?: FilterSetor | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await setorService.getList(filtro ?? {} as FilterSetor);
        setSetor(data);
      }
      else {
        const data = await setorService.getAll(filtro ?? {} as FilterSetor);
        setSetor(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchSetor(currFilter);
    }, [showInc]);
  
    const handleRowClick = (setor: ISetor) => {
      if (isMobile) {
        router.push(`/pages/setor/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${setor.id}`);
      } else {
        setSelectedSetor(setor);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/setor/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedSetor(SetorEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchSetor(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const setor = e.dataItem;		
        setDeleteId(setor.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchSetor(currFilter);
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
           <SetorGridMobileComponent data={setor} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <SetorGridDesktopComponent data={setor} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <SetorWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedSetor={selectedSetor}>       
        </SetorWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default SetorGrid;