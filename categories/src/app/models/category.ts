export interface INode {
    categoryId: number;
    categoryName: string;
    parentCategoryId?: number;
    childCategories?: INode[];
}