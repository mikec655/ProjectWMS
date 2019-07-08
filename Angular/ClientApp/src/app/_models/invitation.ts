import { Guest } from './guest';

export class Invitation {
  public invitationId?: number;
  public invitationPostId?: number;
  public invitationDateUnix?: number;
  public type?: string;
  public numberOfGuests: number;
  public longitude?: number;
  public latitude?: number;
  public address?: string;
  public city?: string;
  public zipCode?: string;
  public number?: string;
  public guests?: Guest[];
}
