namespace OCP.AppFramework.Http.Template
{
/**
 * Class LinkMenuAction
 *
 * @package OCP\AppFramework\Http\Template
 * @since 14.0.0
 */
    class ExternalShareMenuAction : SimpleMenuAction {

    /** @var string */
    private owner;

    /** @var string */
    private displayname;

    /** @var string */
    private shareName;

    /**
     * ExternalShareMenuAction constructor.
     *
     * @param string label
     * @param string icon
     * @param string owner
     * @param string displayname
     * @param string shareName
     * @since 14.0.0
     */
    public function __construct(string label, string icon, string owner, string displayname, string shareName) {
        parent::__construct('save', label, icon);
        this->owner = owner;
        this->displayname = displayname;
        this->shareName = shareName;
    }

    /**
     * @since 14.0.0
     */
    public function render(): string {
        return '<li>' .
        '<a id="save-external-share" data-protected="false" data-owner-display-name="' . Util::sanitizeHTML(this->displayname) . '" data-owner="' . Util::sanitizeHTML(this->owner) . '" data-name="' . Util::sanitizeHTML(this->shareName) . '">' .
        '<span class="icon ' . Util::sanitizeHTML(this->getIcon()) . '"></span>' .
        '<label for="remote_address">' . Util::sanitizeHTML(this->getLabel()) . '</label>' .
        '<form class="save-form hidden" action="#">' .
        '<input type="text" id="remote_address" placeholder="user@yourNextcloud.org">' .
        '<input type="submit" value=" " id="save-button-confirm" class="icon-confirm" disabled="disabled"></button>' .
        '</form>' .
        '</a>' .
        '</li>';
    }
    }

}