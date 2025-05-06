//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ReuniaoPessoasEmpty } from "../../../Models/ReuniaoPessoas";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IReuniaoPessoas } from "../../Interfaces/interface.ReuniaoPessoas";
import { ReuniaoPessoasService } from "../../Services/ReuniaoPessoas.service";
import { ReuniaoPessoasApi } from "../../Apis/ApiReuniaoPessoas";
import { ReuniaoPessoasGridMobileComponent } from "../GridsMobile/ReuniaoPessoas";
import { ReuniaoPessoasGridDesktopComponent } from "../GridsDesktop/ReuniaoPessoas";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterReuniaoPessoas } from "../../Filters/ReuniaoPessoas";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ReuniaoPessoasWindow from "./ReuniaoPessoasWindow";

const ReuniaoPessoasGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [reuniaopessoas, setReuniaoPessoas] = useState<IReuniaoPessoas[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedReuniaoPessoas, setSelectedReuniaoPessoas] = useState<IReuniaoPessoas>(ReuniaoPessoasEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ReuniaoPessoasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterReuniaoPessoas | undefined | null>(null);

    const reuniaopessoasService = useMemo(() => {
      return new ReuniaoPessoasService(
          new ReuniaoPessoasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchReuniaoPessoas = async (filtro?: FilterReuniaoPessoas | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await reuniaopessoasService.getAll(filtro ?? {} as FilterReuniaoPessoas);
        setReuniaoPessoas(data);
      }
      else {
        const data = await reuniaopessoasService.getAll(filtro ?? {} as FilterReuniaoPessoas);
        setReuniaoPessoas(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchReuniaoPessoas(currFilter);
    }, [showInc]);
  
    const handleRowClick = (reuniaopessoas: IReuniaoPessoas) => {
      if (isMobile) {
        router.push(`/pages/reuniaopessoas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${reuniaopessoas.id}`);
      } else {
        setSelectedReuniaoPessoas(reuniaopessoas);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/reuniaopessoas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedReuniaoPessoas(ReuniaoPessoasEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchReuniaoPessoas(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const reuniaopessoas = e.dataItem;		
        setDeleteId(reuniaopessoas.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchReuniaoPessoas(currFilter);
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
            
        {isMobile ?
           <ReuniaoPessoasGridMobileComponent data={reuniaopessoas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ReuniaoPessoasGridDesktopComponent data={reuniaopessoas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ReuniaoPessoasWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedReuniaoPessoas={selectedReuniaoPessoas}>       
        </ReuniaoPessoasWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ReuniaoPessoasGrid;