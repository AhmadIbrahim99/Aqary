interface IEstates {
  estates: { data: IEstate[]; sortable: ISortable[] };
}
interface ISortable {
  key: string;
  value: string;
}
export interface IEstate {
  name: string;
  description: string;
  typeEstate: number;
  status: boolean;
  salary: number;
  priceInDinar: number;
  idUser: number;
  idCategory: number;
  attachments: { imageString: string }[];
  attachmentsString: string[];
  id: number;
  createdAt: string;
  deletedAt: string | null;
  updatedAt: string | null;
}
export { IEstates,ISortable };
