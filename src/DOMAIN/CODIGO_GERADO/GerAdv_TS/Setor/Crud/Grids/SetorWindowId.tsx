// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ISetor } from "../../Interfaces/interface.Setor";
import { SetorService } from "../../Services/Setor.service";
import { SetorApi } from "../../Apis/ApiSetor";
import SetorWindow from "./SetorWindow";

interface SetorWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const SetorWindowId: React.FC<SetorWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const setorService = useMemo(() => {
        return new SetorService(
            new SetorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ISetor | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await setorService.fetchSetorById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <SetorWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedSetor={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default SetorWindowId;