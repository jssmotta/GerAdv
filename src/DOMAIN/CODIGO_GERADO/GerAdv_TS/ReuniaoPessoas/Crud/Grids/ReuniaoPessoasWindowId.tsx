// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IReuniaoPessoas } from "../../Interfaces/interface.ReuniaoPessoas";
import { ReuniaoPessoasService } from "../../Services/ReuniaoPessoas.service";
import { ReuniaoPessoasApi } from "../../Apis/ApiReuniaoPessoas";
import ReuniaoPessoasWindow from "./ReuniaoPessoasWindow";

interface ReuniaoPessoasWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ReuniaoPessoasWindowId: React.FC<ReuniaoPessoasWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const reuniaopessoasService = useMemo(() => {
        return new ReuniaoPessoasService(
            new ReuniaoPessoasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IReuniaoPessoas | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await reuniaopessoasService.fetchReuniaoPessoasById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ReuniaoPessoasWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedReuniaoPessoas={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ReuniaoPessoasWindowId;