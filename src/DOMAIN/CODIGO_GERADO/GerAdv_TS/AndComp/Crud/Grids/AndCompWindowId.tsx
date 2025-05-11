// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAndComp } from "../../Interfaces/interface.AndComp";
import { AndCompService } from "../../Services/AndComp.service";
import { AndCompApi } from "../../Apis/ApiAndComp";
import AndCompWindow from "./AndCompWindow";

interface AndCompWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AndCompWindowId: React.FC<AndCompWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const andcompService = useMemo(() => {
        return new AndCompService(
            new AndCompApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAndComp | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await andcompService.fetchAndCompById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AndCompWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAndComp={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AndCompWindowId;